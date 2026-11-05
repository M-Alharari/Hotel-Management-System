using HotelManagementSystem.Application.Abstractions.Persistence;
using HotelManagementSystem.Domain.Entities;
using MediatR;

namespace HotelManagementSystem.Application.Features.Rooms.Queries.GetRoomById;

public class GetRoomByIdHandler : IRequestHandler<GetRoomByIdQuery, Room?>
{
    private readonly IRoomRepository _roomRepository;

    public GetRoomByIdHandler(IRoomRepository roomRepository)
    {
        _roomRepository = roomRepository;
    }

    public async Task<Room?> Handle(
        GetRoomByIdQuery request,
        CancellationToken cancellationToken)
    {
        return await _roomRepository.GetByIdAsync(request.Id);
    }
}