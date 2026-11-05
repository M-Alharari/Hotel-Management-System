using MediatR;

namespace HotelManagementSystem.Application.Features.Rooms.Commands.CreateRoom;

public class CreateRoomCommand : IRequest<int>
{
    public string RoomNumber { get; set; } = null!;
    public int Floor { get; set; }
    public int RoomTypeId { get; set; }
}