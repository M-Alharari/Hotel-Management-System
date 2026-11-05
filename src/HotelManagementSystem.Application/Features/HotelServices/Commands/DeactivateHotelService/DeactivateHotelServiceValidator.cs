using FluentValidation;

namespace HotelManagementSystem.Application.Features.HotelServices.Commands.DeactivateHotelService;

public class DeactivateHotelServiceValidator
    : AbstractValidator<DeactivateHotelServiceCommand>
{
    public DeactivateHotelServiceValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0);
    }
}