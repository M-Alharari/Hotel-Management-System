using HotelManagementSystem.Application.Features.RoomTypes.Responses;
using MediatR;

namespace HotelManagementSystem.Application.Features.RoomTypes.Queries.GetRoomTypeById;

public class GetRoomTypeByIdQuery : IRequest<RoomTypeResponse>
{
    public int Id { get; set; }
}