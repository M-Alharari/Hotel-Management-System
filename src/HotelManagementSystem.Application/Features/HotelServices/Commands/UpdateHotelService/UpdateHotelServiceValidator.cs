using FluentValidation;

namespace HotelManagementSystem.Application.Features.HotelServices.Commands.UpdateHotelService;

public class UpdateHotelServiceValidator
    : AbstractValidator<UpdateHotelServiceCommand>
{
    public UpdateHotelServiceValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0);

        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.Description)
            .MaximumLength(500);

        RuleFor(x => x.Price)
            .GreaterThanOrEqualTo(0);
    }
}