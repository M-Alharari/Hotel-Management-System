using HotelManagementSystem.Application.Features.RoomTypes.Commands.CreateRoomType;
using HotelManagementSystem.Domain.Entities;

namespace HotelManagementSystem.Application.Mapping;

public static class RoomTypeMapping
{
    public static RoomType ToEntity(this CreateRoomTypeCommand request)
    {
        return new RoomType
        {
            Name = request.Name.Trim(),
            Description = request.Description?.Trim(),
            BasePricePerNight = request.BasePricePerNight,
            MaxOccupancy = request.MaxOccupancy,
            IsActive = true
        };
    }
}