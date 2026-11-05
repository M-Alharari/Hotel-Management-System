using FluentValidation;

namespace HotelManagementSystem.Application.Features.ServiceUsages.Commands.CreateServiceUsage;

public class CreateServiceUsageValidator
    : AbstractValidator<CreateServiceUsageCommand>
{
    public CreateServiceUsageValidator()
    {
        RuleFor(x => x.ReservationId)
            .GreaterThan(0);

        RuleFor(x => x.HotelServiceId)
            .GreaterThan(0);

        RuleFor(x => x.Quantity)
            .GreaterThan(0);
    }
}