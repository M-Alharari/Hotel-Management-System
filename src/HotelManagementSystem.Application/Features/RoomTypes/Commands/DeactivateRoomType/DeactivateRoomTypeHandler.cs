using HotelManagementSystem.Application.Abstractions.Persistence;
using MediatR;

namespace HotelManagementSystem.Application.Features.RoomTypes.Commands.DeactivateRoomType;

public class DeactivateRoomTypeHandler
    : IRequestHandler<DeactivateRoomTypeCommand>
{
    private readonly IRoomTypeRepository _repository;

    public DeactivateRoomTypeHandler(IRoomTypeRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(
        DeactivateRoomTypeCommand request,
        CancellationToken cancellationToken)
    {
        var roomType = await _repository.GetByIdAsync(request.Id);

        if (roomType is null)
            throw new KeyNotFoundException("Room type not found.");

        roomType.IsActive = false;

         await _repository.UpdateAsync(roomType);
    }
}