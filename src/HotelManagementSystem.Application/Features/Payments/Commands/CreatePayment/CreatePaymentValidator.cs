using FluentValidation;

namespace HotelManagementSystem.Application.Features.Payments.Commands.CreatePayment;

public class CreatePaymentValidator : AbstractValidator<CreatePaymentCommand>
{
    public CreatePaymentValidator()
    {
        RuleFor(x => x.ReservationId)
            .GreaterThan(0);

        RuleFor(x => x.Amount)
            .GreaterThan(0);

        RuleFor(x => x.Method)
            .IsInEnum();

        RuleFor(x => x.TransactionReference)
            .MaximumLength(200);
    }
}