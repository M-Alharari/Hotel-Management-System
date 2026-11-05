using HotelManagementSystem.Application.Abstractions.Persistence;
using HotelManagementSystem.Application.Mapping;
using MediatR;

namespace HotelManagementSystem.Application.Features.HotelServices.Commands.UpdateHotelService;

public class UpdateHotelServiceHandler
    : IRequestHandler<UpdateHotelServiceCommand>
{
    private readonly IHotelServiceRepository _repository;

    public UpdateHotelServiceHandler(IHotelServiceRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(
        UpdateHotelServiceCommand request,
        CancellationToken cancellationToken)
    {
        var service = await _repository.GetByIdAsync(request.Id);

        if (service == null)
            throw new KeyNotFoundException("Service was not found.");

        var name = request.Name.Trim();

        if (await _repository.ExistsByNameAsync(name, request.Id))
            throw new InvalidOperationException(
                "Another service already uses this name.");

        request.UpdateEntity(service);

        await _repository.UpdateAsync(service);
    }
}