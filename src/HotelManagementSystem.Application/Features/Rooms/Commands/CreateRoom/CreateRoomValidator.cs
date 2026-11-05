using FluentValidation;

namespace HotelManagementSystem.Application.Features.Rooms.Commands.CreateRoom;

public class CreateRoomValidator : AbstractValidator<CreateRoomCommand>
{
    public CreateRoomValidator()
    {
        RuleFor(x => x.RoomNumber)
            .NotEmpty()
            .MaximumLength(20);

        RuleFor(x => x.Floor)
            .GreaterThanOrEqualTo(0);

        RuleFor(x => x.RoomTypeId)
            .GreaterThan(0);
    }
}