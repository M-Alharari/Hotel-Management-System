using HotelManagementSystem.Application.Features.ServiceUsages.Models;
using MediatR;

namespace HotelManagementSystem.Application.Features.ServiceUsages.Queries.GetAllServiceUsages;

public record GetAllServiceUsagesQuery
    : IRequest<IEnumerable<ServiceUsageResponse>>;