using HotelManagementSystem.Application.Features.RoomTypes.Responses;
using MediatR;

namespace HotelManagementSystem.Application.Features.RoomTypes.Queries.GetAllRoomTypes;

public class GetAllRoomTypesQuery : IRequest<IEnumerable<RoomTypeResponse>>
{
}