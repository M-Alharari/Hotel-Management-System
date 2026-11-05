using FluentValidation;

namespace HotelManagementSystem.Application.Features.Countries.Commands.CreateCountry;

public class CreateCountryValidator : AbstractValidator<CreateCountryCommand>
{
    public CreateCountryValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.CountryCode)
            .NotEmpty()
            .Length(2)
            .Matches("^[A-Z]{2}$");
    }
}