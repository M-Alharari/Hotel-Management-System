using FluentValidation;

namespace HotelManagementSystem.Application.Features.Reservations.Commands.CreateReservation;

public class CreateReservationValidator
    : AbstractValidator<CreateReservationCommand>
{
    public CreateReservationValidator()
    {
        RuleFor(x => x.PrimaryGuestId)
            .GreaterThan(0);

        RuleFor(x => x.CheckInDate)
            .NotEmpty();

        RuleFor(x => x.CheckOutDate)
            .GreaterThan(x => x.CheckInDate);

        RuleFor(x => x.SpecialRequests)
            .MaximumLength(500);

        RuleFor(x => x.Rooms)
            .NotEmpty()
            .Must(rooms => rooms.Select(r => r.RoomId).Distinct().Count()
                           == rooms.Count)
            .WithMessage("Duplicate rooms are not allowed.");

        RuleForEach(x => x.Rooms).ChildRules(room =>
        {
            room.RuleFor(x => x.RoomId)
                .GreaterThan(0);

            room.RuleFor(x => x.Adults)
                .GreaterThan(0);

            room.RuleFor(x => x.Children)
                .GreaterThanOrEqualTo(0);
        });
    }
}