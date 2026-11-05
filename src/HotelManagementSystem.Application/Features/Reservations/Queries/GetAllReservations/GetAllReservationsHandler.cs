using HotelManagementSystem.Application.Abstractions.Persistence;
using HotelManagementSystem.Application.Mapping;
using HotelManagementSystem.Application.Features.Reservations.Responses;
using MediatR;

namespace HotelManagementSystem.Application.Features.Reservations.Queries.GetAllReservations;

public class GetAllReservationsHandler
    : IRequestHandler<GetAllReservationsQuery, IEnumerable<ReservationResponse>>
{
    private readonly IReservationRepository _repository;

    public GetAllReservationsHandler(IReservationRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<ReservationResponse>> Handle(
      GetAllReservationsQuery request,
      CancellationToken cancellationToken)
    {
        var reservations = await _repository.GetAllAsync();

        return reservations.Select(r => r.ToResponse());
    }
}