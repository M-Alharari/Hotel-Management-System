using HotelManagementSystem.Application.Abstractions.Persistence;
using HotelManagementSystem.Application.Features.HotelServices;
using HotelManagementSystem.Application.Mapping;
using MediatR;

namespace HotelManagementSystem.Application.Features.HotelServices.Queries.GetHotelServiceById;

public class GetHotelServiceByIdHandler
    : IRequestHandler<GetHotelServiceByIdQuery, HotelServiceResponse>
{
    private readonly IHotelServiceRepository _repository;

    public GetHotelServiceByIdHandler(IHotelServiceRepository repository)
    {
        _repository = repository;
    }

    public async Task<HotelServiceResponse> Handle(
        GetHotelServiceByIdQuery request,
        CancellationToken cancellationToken)
    {
        var service = await _repository.GetByIdAsync(request.Id);

        if (service == null)
            throw new KeyNotFoundException("Service was not found.");

        return service.ToResponse();
    }
}