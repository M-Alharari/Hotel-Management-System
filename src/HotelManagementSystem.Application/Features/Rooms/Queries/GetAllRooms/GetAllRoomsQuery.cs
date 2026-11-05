using HotelManagementSystem.Application.Features.Rooms.Response;
using HotelManagementSystem.Domain.Entities;
using MediatR;

namespace HotelManagementSystem.Application.Features.Rooms.Queries.GetAllRooms;

public class GetAllRoomsQuery : IRequest<IEnumerable<RoomResponse>>
{
}