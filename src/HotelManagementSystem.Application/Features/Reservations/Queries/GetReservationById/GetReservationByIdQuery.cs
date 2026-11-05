using HotelManagementSystem.Application.Features.Reservations.Responses;
using MediatR;

namespace HotelManagementSystem.Application.Features.Reservations.Queries.GetReservationById;

public class GetReservationByIdQuery : IRequest<ReservationResponse>
{
    public int Id { get; set; }
}