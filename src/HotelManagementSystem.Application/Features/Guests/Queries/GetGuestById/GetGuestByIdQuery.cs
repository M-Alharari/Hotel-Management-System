using HotelManagementSystem.Domain.Entities;
using MediatR;

namespace HotelManagementSystem.Application.Features.Guests.Queries.GetGuestById;

public class GetGuestByIdQuery : IRequest<Guest?>
{
    public int Id { get; set; }
}