using HotelManagementSystem.Domain.Enums;
using MediatR;

namespace HotelManagementSystem.Application.Features.Payments.Commands.CreatePayment;

public record CreatePaymentCommand(
    int ReservationId,
    decimal Amount,
    PaymentMethod Method,
    string? TransactionReference
) : IRequest<int>;