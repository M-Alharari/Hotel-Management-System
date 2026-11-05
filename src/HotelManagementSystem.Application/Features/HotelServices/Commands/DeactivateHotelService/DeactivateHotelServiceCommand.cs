using MediatR;

namespace HotelManagementSystem.Application.Features.HotelServices.Commands.DeactivateHotelService;

public record DeactivateHotelServiceCommand(int Id) : IRequest;