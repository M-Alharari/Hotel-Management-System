using MediatR;

namespace HotelManagementSystem.Application.Features.RoomTypes.Commands.UpdateRoomType;

public class UpdateRoomTypeCommand : IRequest
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public decimal BasePricePerNight { get; set; }
    public int MaxOccupancy { get; set; }
}