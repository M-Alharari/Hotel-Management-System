using HotelManagementSystem.Application.Abstractions.Persistence;
using HotelManagementSystem.Application.Features.ServiceUsages.Models;
using HotelManagementSystem.Application.Mapping;
using MediatR;

namespace HotelManagementSystem.Application.Features.ServiceUsages.Queries.GetServiceUsageById;

public class GetServiceUsageByIdHandler
    : IRequestHandler<GetServiceUsageByIdQuery, ServiceUsageResponse>
{
    private readonly IServiceUsageRepository _repository;

    public GetServiceUsageByIdHandler(IServiceUsageRepository repository)
    {
        _repository = repository;
    }

    public async Task<ServiceUsageResponse> Handle(
        GetServiceUsageByIdQuery request,
        CancellationToken cancellationToken)
    {
        if (request.Id <= 0)
            throw new ArgumentException("Invalid usage ID.");

        var usage = await _repository.GetByIdAsync(request.Id);

        if (usage == null)
            throw new KeyNotFoundException(
                "Service usage was not found.");

        return usage.ToResponse();
    }
}