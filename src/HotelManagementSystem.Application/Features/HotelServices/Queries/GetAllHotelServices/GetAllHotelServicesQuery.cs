using HotelManagementSystem.Application.Features.HotelServices;
using MediatR;

namespace HotelManagementSystem.Application.Features.HotelServices.Queries.GetAllHotelServices;

public record GetAllHotelServicesQuery
    : IRequest<IEnumerable<HotelServiceResponse>>;