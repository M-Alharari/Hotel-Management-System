using HotelManagementSystem.Application.Features.Invoices.Responses;
using HotelManagementSystem.Domain.Entities;

namespace HotelManagementSystem.Application.Mapping;

public static class InvoiceMapping
{
    public static InvoiceResponse ToResponse(this Invoice invoice)
    {
        var paidAmount = invoice.PaymentAllocations.Sum(x => x.Amount);

        return new InvoiceResponse
        {
            Id = invoice.Id,
            InvoiceNumber = invoice.InvoiceNumber,
            ReservationId = invoice.ReservationId,
            TotalAmount = invoice.TotalAmount,
            PaidAmount = paidAmount,
            RemainingBalance = invoice.TotalAmount - paidAmount,
            Status = invoice.Status.ToString(),
            CreatedAt = invoice.CreatedAt,
            IssuedAt = invoice.IssuedAt,

            InvoiceLines = invoice.InvoiceLines.Select(line =>
                new InvoiceLineResponse
                {
                    Id = line.Id,
                    Description = line.Description,
                    Quantity = line.Quantity,
                    UnitPrice = line.UnitPrice,
                    
                }).ToList()
        };
    }
}