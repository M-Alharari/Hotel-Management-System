using HotelManagementSystem.Application.Features.Countries.Commands.CreateCountry;
using HotelManagementSystem.Domain.Entities;

namespace HotelManagementSystem.Application.Mapping;

public static class CountryMapping
{
    public static Country ToEntity(this CreateCountryCommand command)
    {
        return new Country
        {
            Name = command.Name,
            CountryCode = command.CountryCode
        };
    }
}