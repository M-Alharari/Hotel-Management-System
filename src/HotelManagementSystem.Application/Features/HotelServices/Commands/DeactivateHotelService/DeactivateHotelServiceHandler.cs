using HotelManagementSystem.Application.Abstractions.Persistence;
using MediatR;

namespace HotelManagementSystem.Application.Features.HotelServices.Commands.DeactivateHotelService;

public class DeactivateHotelServiceHandler
    : IRequestHandler<DeactivateHotelServiceCommand>
{
    private readonly IHotelServiceRepository _repository;

    public DeactivateHotelServiceHandler(
        IHotelServiceRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(
        DeactivateHotelServiceCommand request,
        CancellationToken cancellationToken)
    {
        var service = await _repository.GetByIdAsync(request.Id);

        if (service == null)
            throw new KeyNotFoundException("Service was not found.");

        if (!service.IsActive)
            throw new InvalidOperationException(
                "Service is already inactive.");

        service.IsActive = false;

        await _repository.UpdateAsync(service);
    }
}