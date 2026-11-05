using HotelManagementSystem.Application.Abstractions.Persistence;
using HotelManagementSystem.Application.Features.HotelServices;
using HotelManagementSystem.Application.Mapping;
using MediatR;

namespace HotelManagementSystem.Application.Features.HotelServices.Queries.GetAllHotelServices;

public class GetAllHotelServicesHandler
    : IRequestHandler<GetAllHotelServicesQuery, IEnumerable<HotelServiceResponse>>
{
    private readonly IHotelServiceRepository _repository;

    public GetAllHotelServicesHandler(IHotelServiceRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<HotelServiceResponse>> Handle(
        GetAllHotelServicesQuery request,
        CancellationToken cancellationToken)
    {
        var services = await _repository.GetAllAsync();

        return services.Select(x => x.ToResponse());
    }
}