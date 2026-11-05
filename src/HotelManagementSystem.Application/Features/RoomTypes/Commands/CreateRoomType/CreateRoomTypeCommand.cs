using MediatR;

namespace HotelManagementSystem.Application.Features.RoomTypes.Commands.CreateRoomType;

public class CreateRoomTypeCommand : IRequest<int>
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public decimal BasePricePerNight { get; set; }
    public int MaxOccupancy { get; set; }
}