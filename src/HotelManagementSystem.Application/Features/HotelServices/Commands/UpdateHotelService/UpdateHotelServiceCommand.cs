using MediatR;

namespace HotelManagementSystem.Application.Features.HotelServices.Commands.UpdateHotelService;

public class UpdateHotelServiceCommand : IRequest
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public decimal Price { get; set; }
}