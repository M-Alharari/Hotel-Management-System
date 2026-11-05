using MediatR;

namespace HotelManagementSystem.Application.Features.Guests.Commands.CreateGuest;

public class CreateGuestCommand : IRequest<int>
{
    public int PersonId { get; set; }

   
}