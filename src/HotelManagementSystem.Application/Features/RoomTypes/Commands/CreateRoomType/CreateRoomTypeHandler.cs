using HotelManagementSystem.Application.Abstractions.Persistence;
using HotelManagementSystem.Application.Mapping;
using MediatR;

namespace HotelManagementSystem.Application.Features.RoomTypes.Commands.CreateRoomType;

public class CreateRoomTypeHandler : IRequestHandler<CreateRoomTypeCommand, int>
{
    private readonly IRoomTypeRepository _roomTypeRepository;

    public CreateRoomTypeHandler(IRoomTypeRepository roomTypeRepository)
    {
        _roomTypeRepository = roomTypeRepository;
    }

    public async Task<int> Handle(
        CreateRoomTypeCommand request,
        CancellationToken cancellationToken)
    {
        var name = request.Name.Trim();

        var exists = await _roomTypeRepository.ExistsByNameAsync(name);

        if (exists)
            throw new InvalidOperationException("Room type already exists.");

        var roomType = request.ToEntity();

        await _roomTypeRepository.AddAsync(roomType);

        return roomType.Id;
    }
}