using HotelManagementSystem.Application.Features.Guests.Commands.CreateGuest;
using HotelManagementSystem.Domain.Entities;

namespace HotelManagementSystem.Application.Mapping;

public static class GuestMapping
{
    public static Guest ToEntity(this CreateGuestCommand command)
    {
        return new Guest
        {
            PersonId = command.PersonId,
            
        };
    }
}