using HotelManagementSystem.Domain.Entities;
using HotelManagementSystem.Application.Features.People.Commands.CreatePerson;

namespace HotelManagementSystem.Application.Mapping;

public static class PersonMapping
{
    public static Person ToEntity(this CreatePersonCommand command)
    {
        return new Person
        {
            FirstName = command.FirstName,
            LastName = command.LastName,
            Email = command.Email,
            PhoneNumber = command.PhoneNumber,
            Address = command.Address,
            CountryId = command.CountryId
        };
    }
}