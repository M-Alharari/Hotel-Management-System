using FluentValidation;

namespace HotelManagementSystem.Application.Features.Guests.Commands.CreateGuest;

public class CreateGuestValidator : AbstractValidator<CreateGuestCommand>
{
    public CreateGuestValidator()
    {
        RuleFor(x => x.PersonId)
            .GreaterThan(0);
        
    }
}