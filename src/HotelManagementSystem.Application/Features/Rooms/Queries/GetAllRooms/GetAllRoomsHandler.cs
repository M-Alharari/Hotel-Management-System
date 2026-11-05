using HotelManagementSystem.Application.Abstractions.Persistence;
using HotelManagementSystem.Application.Features.Rooms.Response;
using HotelManagementSystem.Application.Mapping;
using MediatR;

namespace HotelManagementSystem.Application.Features.Rooms.Queries.GetAllRooms;

public class GetAllRoomsHandler
    : IRequestHandler<GetAllRoomsQuery, IEnumerable<RoomResponse>>
{
    private readonly IRoomRepository _roomRepository;

    public GetAllRoomsHandler(IRoomRepository roomRepository)
    {
        _roomRepository = roomRepository;
    }

    public async Task<IEnumerable<RoomResponse>> Handle(
        GetAllRoomsQuery request,
        CancellationToken cancellationToken)
    {
        var rooms = await _roomRepository.GetAllAsync();

        return rooms.Select(room => room.ToResponse());
    }
}