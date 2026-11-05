using FluentValidation;

namespace HotelManagementSystem.Application.Features.RoomTypes.Commands.UpdateRoomType;

public class UpdateRoomTypeValidator : AbstractValidator<UpdateRoomTypeCommand>
{
    public UpdateRoomTypeValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0);

        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(x => x.Description)
            .MaximumLength(250);

        RuleFor(x => x.BasePricePerNight)
            .GreaterThan(0);

        RuleFor(x => x.MaxOccupancy)
            .GreaterThan(0);
    }
}