using MediatR;

namespace HotelManagementSystem.Application.Features.Payments.Commands.AllocatePayment;

public record AllocatePaymentCommand(
    int PaymentId,
    int InvoiceId,
    decimal Amount) : IRequest<int>;