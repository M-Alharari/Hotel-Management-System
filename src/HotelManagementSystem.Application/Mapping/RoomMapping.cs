using HotelManagementSystem.Application.Features.Rooms.Commands.CreateRoom;
using HotelManagementSystem.Application.Features.Rooms.Response;
using HotelManagementSystem.Domain.Entities;

namespace HotelManagementSystem.Application.Mapping;

public static class RoomMapping
{
    public static Room ToEntity(this CreateRoomCommand command)
    {
        return new Room
        {
            RoomNumber = command.RoomNumber.Trim(),
            Floor = command.Floor,
            RoomTypeId = command.RoomTypeId
        };
    }


    public static RoomResponse ToResponse(this Room room)
    {
        return new RoomResponse
        {
            Id = room.Id,
            RoomNumber = room.RoomNumber,
            RoomTypeName = room.RoomType.Name,

        };
    }
}
