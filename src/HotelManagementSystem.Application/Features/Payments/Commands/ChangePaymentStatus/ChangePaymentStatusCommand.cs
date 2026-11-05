using HotelManagementSystem.Domain.Enums;
using MediatR;

namespace HotelManagementSystem.Application.Features.Payments.Commands.ChangePaymentStatus;

public record ChangePaymentStatusCommand(
    int Id,
    PaymentStatus Status
) : IRequest<bool>;