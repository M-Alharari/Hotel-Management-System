using HotelManagementSystem.Domain.Enums;

namespace HotelManagementSystem.Application.Features.Payments.Commands.ChangePaymentStatus;

public record ChangePaymentStatusRequest(PaymentStatus Status);