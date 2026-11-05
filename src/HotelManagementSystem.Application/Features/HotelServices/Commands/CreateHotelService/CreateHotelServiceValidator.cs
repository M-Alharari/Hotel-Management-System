using FluentValidation;

namespace HotelManagementSystem.Application.Features.HotelServices.Commands.CreateHotelService;

public class CreateHotelServiceValidator
    : AbstractValidator<CreateHotelServiceCommand>
{
    public CreateHotelServiceValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.Description)
            .MaximumLength(500);

        RuleFor(x => x.Price)
            .GreaterThanOrEqualTo(0);
    }
}