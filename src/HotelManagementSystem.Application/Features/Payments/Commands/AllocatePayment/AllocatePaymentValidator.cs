using FluentValidation;

namespace HotelManagementSystem.Application.Features.Payments.Commands.AllocatePayment;

public class AllocatePaymentValidator
    : AbstractValidator<AllocatePaymentCommand>
{
    public AllocatePaymentValidator()
    {
        RuleFor(x => x.PaymentId).GreaterThan(0);
        RuleFor(x => x.InvoiceId).GreaterThan(0);
        RuleFor(x => x.Amount).GreaterThan(0);
    }
}