using HotelManagementSystem.Application.Abstractions.Persistence;
using HotelManagementSystem.Application.Mapping;
using HotelManagementSystem.Application.Features.Reservations.Responses;
using MediatR;

namespace HotelManagementSystem.Application.Features.Reservations.Queries.GetReservationById;

public class GetReservationByIdHandler
    : IRequestHandler<GetReservationByIdQuery, ReservationResponse>
{
    private readonly IReservationRepository _repository;

    public GetReservationByIdHandler(IReservationRepository repository)
    {
        _repository = repository;
    }

    public async Task<ReservationResponse> Handle(
        GetReservationByIdQuery request,
        CancellationToken cancellationToken)
    {
        var reservation = await _repository.GetByIdAsync(request.Id);

        if (reservation is null)
            throw new KeyNotFoundException("Reservation not found.");

        return reservation.ToResponse();
    }
}