using FluentValidation;
using HotelManagementSystem.Domain.Enums;

namespace HotelManagementSystem.Application.Features.Payments.Commands.ChangePaymentStatus;

public class ChangePaymentStatusValidator
    : AbstractValidator<ChangePaymentStatusCommand>
{
    public ChangePaymentStatusValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0);

        RuleFor(x => x.Status)
            .IsInEnum()
            .Must(status => status != PaymentStatus.Pending)
            .WithMessage("A payment cannot be changed back to Pending.");
    }
}