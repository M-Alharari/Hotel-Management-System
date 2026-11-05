using HotelManagementSystem.Application.Abstractions.Persistence;
using HotelManagementSystem.Domain.Entities;
using MediatR;

namespace HotelManagementSystem.Application.Features.Guests.Queries.GetGuestById;

public class GetGuestByIdHandler
    : IRequestHandler<GetGuestByIdQuery, Guest?>
{
    private readonly IGuestRepository _guestRepository;

    public GetGuestByIdHandler(IGuestRepository guestRepository)
    {
        _guestRepository = guestRepository;
    }

    public async Task<Guest?> Handle(
        GetGuestByIdQuery request,
        CancellationToken cancellationToken)
    {
        return await _guestRepository.GetByIdAsync(request.Id);
    }
}