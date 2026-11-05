using MediatR;

namespace HotelManagementSystem.Application.Features.People.Commands.CreatePerson;

public class CreatePersonCommand : IRequest<int>
{
    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Email { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public string? Address { get; set; }

    public int CountryId { get; set; }
}