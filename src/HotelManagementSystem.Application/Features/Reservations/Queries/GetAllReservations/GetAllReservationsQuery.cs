using HotelManagementSystem.Application.Features.Reservations.Responses;
using MediatR;

namespace HotelManagementSystem.Application.Features.Reservations.Queries.GetAllReservations;

public class GetAllReservationsQuery
    : IRequest<IEnumerable<ReservationResponse>>
{
}