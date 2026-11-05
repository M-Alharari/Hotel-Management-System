using MediatR;

namespace HotelManagementSystem.Application.Features.HotelServices.Commands.CreateHotelService;

public class CreateHotelServiceCommand : IRequest<int>
{
    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public decimal Price { get; set; }
}