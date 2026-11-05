using HotelManagementSystem.Application.Features.HotelServices;
using MediatR;

namespace HotelManagementSystem.Application.Features.HotelServices.Queries.GetHotelServiceById;

public record GetHotelServiceByIdQuery(int Id)
    : IRequest<HotelServiceResponse>;