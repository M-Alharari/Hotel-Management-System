using HotelManagementSystem.Application.Abstractions.Persistence;
using HotelManagementSystem.Application.Features.ServiceUsages.Models;
using HotelManagementSystem.Application.Mapping;
using MediatR;

namespace HotelManagementSystem.Application.Features.ServiceUsages.Queries.GetAllServiceUsages;

public class GetAllServiceUsagesHandler
    : IRequestHandler<GetAllServiceUsagesQuery, IEnumerable<ServiceUsageResponse>>
{
    private readonly IServiceUsageRepository _repository;

    public GetAllServiceUsagesHandler(IServiceUsageRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<ServiceUsageResponse>> Handle(
        GetAllServiceUsagesQuery request,
        CancellationToken cancellationToken)
    {
        var usages = await _repository.GetAllAsync();

        return usages.Select(x => x.ToResponse());
    }
}