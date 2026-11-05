using MediatR;

namespace HotelManagementSystem.Application.Features.Countries.Commands.CreateCountry;

public class CreateCountryCommand : IRequest<int>
{
    public string Name { get; set; } = null!;

    public string CountryCode { get; set; } = null!;
}