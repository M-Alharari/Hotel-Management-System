using FluentValidation;

namespace HotelManagementSystem.Application.Features.Reservations.Commands.ChangeReservationStatus;

public class ChangeReservationStatusValidator
    : AbstractValidator<ChangeReservationStatusCommand>
{
    public ChangeReservationStatusValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0);

        RuleFor(x => x.Status)
            .IsInEnum();
    }
}