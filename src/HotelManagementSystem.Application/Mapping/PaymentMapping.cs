using HotelManagementSystem.Application.Features.Payments.Responses;
using HotelManagementSystem.Domain.Entities;

namespace HotelManagementSystem.Application.Mapping;

public static class PaymentMapping
{
    public static PaymentResponse ToResponse(this Payment payment)
    {
        return new PaymentResponse
        {
            Id = payment.Id,
            ReservationId = payment.ReservationId,
            Amount = payment.Amount,
            Method = payment.Method.ToString(),
            Status = payment.Status.ToString(),
            TransactionReference = payment.TransactionReference,
            ReceivedAt = payment.ReceivedAt,
            CreatedAt = payment.CreatedAt
        };
    }
}