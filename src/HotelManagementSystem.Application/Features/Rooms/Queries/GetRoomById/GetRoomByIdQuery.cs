using HotelManagementSystem.Domain.Entities;
using MediatR;

namespace HotelManagementSystem.Application.Features.Rooms.Queries.GetRoomById;

public class GetRoomByIdQuery : IRequest<Room?>
{
    public int Id { get; set; }
}