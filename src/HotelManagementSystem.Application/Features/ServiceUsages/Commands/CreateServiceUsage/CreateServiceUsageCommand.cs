using MediatR;

namespace HotelManagementSystem.Application.Features.ServiceUsages.Commands.CreateServiceUsage;

public class CreateServiceUsageCommand : IRequest<int>
{
    public int ReservationId { get; set; }

    public int HotelServiceId { get; set; }

    public int Quantity { get; set; }
}