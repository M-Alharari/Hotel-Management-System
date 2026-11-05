using HotelManagementSystem.Application.Abstractions.Persistence;
using HotelManagementSystem.Domain.Entities;
using HotelManagementSystem.Domain.Enums;
using MediatR;

namespace HotelManagementSystem.Application.Features.Invoices.Commands.CreateInvoice;

public class CreateInvoiceHandler
    : IRequestHandler<CreateInvoiceCommand, int>
{
    private readonly IInvoiceRepository _invoiceRepository;
    private readonly IReservationRepository _reservationRepository;

    public CreateInvoiceHandler(
        IInvoiceRepository invoiceRepository,
        IReservationRepository reservationRepository)
    {
        _invoiceRepository = invoiceRepository;
        _reservationRepository = reservationRepository;
    }

    public async Task<int> Handle(
        CreateInvoiceCommand request,
        CancellationToken cancellationToken)
    {
        // 1. Get reservation with its rooms and service usages
        var reservation = await _reservationRepository
            .GetForInvoiceAsync(request.ReservationId);

        if (reservation is null)
            throw new KeyNotFoundException("Reservation not found.");

        // 2. Validate reservation status
        if (reservation.Status == ReservationStatus.Cancelled ||
            reservation.Status == ReservationStatus.NoShow)
        {
            throw new InvalidOperationException(
                "Cannot create an invoice for a cancelled or no-show reservation.");
        }

        // 3. Validate reservation dates
        if (reservation.CheckOutDate <= reservation.CheckInDate)
        {
            throw new InvalidOperationException(
                "Invalid reservation dates.");
        }

        // 4. Prevent duplicate invoices
        var existingInvoice = await _invoiceRepository
            .GetByReservationIdAsync(reservation.Id);

        if (existingInvoice.Any())
        {
            throw new InvalidOperationException(
                "An invoice already exists for this reservation.");
        }

        // 5. Calculate reservation nights
        var nights = reservation.CheckOutDate.DayNumber
                   - reservation.CheckInDate.DayNumber;

        var now = DateTime.UtcNow;

        // 6. Create invoice
        var invoice = new Invoice
        {
            InvoiceNumber =
                $"INV-{now:yyyyMMddHHmmss}-{Guid.NewGuid():N}"[..29],

            ReservationId = reservation.Id,

            Status = InvoiceStatus.Issued,

            CreatedAt = now,

            IssuedAt = now
        };

        // 7. Add room invoice lines
        foreach (var reservationRoom in reservation.ReservationRooms)
        {
            invoice.InvoiceLines.Add(new InvoiceLine
            {
                Description =
                    $"Room {reservationRoom.Room.RoomNumber} - {nights} nights",

                Quantity = nights,

                UnitPrice = reservationRoom.PricePerNight,

                ReservationRoomId = reservationRoom.Id
            });
        }

        // 8. Add service usage invoice lines
        foreach (var usage in reservation.ServiceUsages)
        {
            invoice.InvoiceLines.Add(new InvoiceLine
            {
                Description = usage.HotelService.Name,

                Quantity = usage.Quantity,

                UnitPrice = usage.UnitPrice,

                ServiceUsageId = usage.Id
            });
        }

        // 9. Prevent empty invoices
        if (!invoice.InvoiceLines.Any())
        {
            throw new InvalidOperationException(
                "Cannot create an empty invoice.");
        }

        // 10. Calculate invoice total
        invoice.TotalAmount = invoice.InvoiceLines.Sum(
            line => line.Quantity * line.UnitPrice);

        // 11. Save invoice
        await _invoiceRepository.AddAsync(invoice);

        return invoice.Id;
    }
}