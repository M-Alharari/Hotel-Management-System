using MediatR;

namespace HotelManagementSystem.Application.Features.RoomTypes.Commands.DeactivateRoomType;

public class DeactivateRoomTypeCommand : IRequest
{
    public int Id { get; set; }
}