using HotelManagementSystem.Application.Abstractions.Persistence;
using HotelManagementSystem.Application.Mapping;
using MediatR;

namespace HotelManagementSystem.Application.Features.Rooms.Commands.CreateRoom;

public class CreateRoomHandler : IRequestHandler<CreateRoomCommand, int>
{
    private readonly IRoomRepository _roomRepository;
    private readonly IRoomTypeRepository _roomTypeRepository;

    public CreateRoomHandler(
        IRoomRepository roomRepository,
        IRoomTypeRepository roomTypeRepository)
    {
        _roomRepository = roomRepository;
        _roomTypeRepository = roomTypeRepository;
    }

    public async Task<int> Handle(
        CreateRoomCommand request,
        CancellationToken cancellationToken)
    {
        var roomType = await _roomTypeRepository.GetByIdAsync(request.RoomTypeId);

        if (roomType is null)
            throw new KeyNotFoundException("Room type not found.");

        var rooms = await _roomRepository.GetAllAsync();

        if (rooms.Any(r =>
            r.RoomNumber.Equals(
                request.RoomNumber.Trim(),
                StringComparison.OrdinalIgnoreCase)))
        {
            throw new InvalidOperationException("Room number already exists.");
        }

        var room = request.ToEntity();

        await _roomRepository.AddAsync(room);

        return room.Id;
    }
}