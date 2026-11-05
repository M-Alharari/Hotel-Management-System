using HotelManagementSystem.Application.Abstractions.Persistence;
using HotelManagementSystem.Application.Mapping;
using MediatR;

namespace HotelManagementSystem.Application.Features.HotelServices.Commands.CreateHotelService;

public class CreateHotelServiceHandler
    : IRequestHandler<CreateHotelServiceCommand, int>
{
    private readonly IHotelServiceRepository _repository;

    public CreateHotelServiceHandler(IHotelServiceRepository repository)
    {
        _repository = repository;
    }

    public async Task<int> Handle(
        CreateHotelServiceCommand request,
        CancellationToken cancellationToken)
    {
        var name = request.Name.Trim();

        if (await _repository.ExistsByNameAsync(name))
            throw new InvalidOperationException(
                "A service with this name already exists.");

        var service = request.ToEntity();

        await _repository.AddAsync(service);

        return service.Id;
    }
}