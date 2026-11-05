using HotelManagementSystem.Application.Abstractions.Persistence;
using HotelManagementSystem.Domain.Entities;
using HotelManagementSystem.Domain.Enums;
using MediatR;

namespace HotelManagementSystem.Application.Features.Payments.Commands.CreatePayment;

public class CreatePaymentHandler
    : IRequestHandler<CreatePaymentCommand, int>
{
    private readonly IPaymentRepository _paymentRepository;
    private readonly IReservationRepository _reservationRepository;

    public CreatePaymentHandler(
        IPaymentRepository paymentRepository,
        IReservationRepository reservationRepository)
    {
        _paymentRepository = paymentRepository;
        _reservationRepository = reservationRepository;
    }

    public async Task<int> Handle(
        CreatePaymentCommand request,
        CancellationToken cancellationToken)
    {
        var reservation = await _reservationRepository
            .GetByIdAsync(request.ReservationId);

        if (reservation is null)
            throw new KeyNotFoundException("Reservation not found.");

        var payment = new Payment
        {
            ReservationId = request.ReservationId,
            Amount = request.Amount,
            Method = request.Method,
            Status = PaymentStatus.Pending,
            TransactionReference = request.TransactionReference?.Trim(),
            CreatedAt = DateTime.UtcNow
        };

        await _paymentRepository.AddAsync(payment);

        return payment.Id;
    }
}