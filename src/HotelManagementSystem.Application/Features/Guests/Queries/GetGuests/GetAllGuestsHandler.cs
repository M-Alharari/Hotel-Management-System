using HotelManagementSystem.Application.Abstractions.Persistence;
using HotelManagementSystem.Domain.Entities;
using MediatR;

namespace HotelManagementSystem.Application.Features.Guests.Queries.GetAllGuests;

public class GetAllGuestsHandler
    : IRequestHandler<GetAllGuestsQuery, IEnumerable<Guest>>
{
    private readonly IGuestRepository _guestRepository;

    public GetAllGuestsHandler(IGuestRepository guestRepository)
    {
        _guestRepository = guestRepository;
    }

    public async Task<IEnumerable<Guest>> Handle(
        GetAllGuestsQuery request,
        CancellationToken cancellationToken)
    {
        return await _guestRepository.GetAllAsync();
    }
}