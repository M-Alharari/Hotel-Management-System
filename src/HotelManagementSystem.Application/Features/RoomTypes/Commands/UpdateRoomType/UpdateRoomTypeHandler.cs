using HotelManagementSystem.Application.Abstractions.Persistence;
using MediatR;

namespace HotelManagementSystem.Application.Features.RoomTypes.Commands.UpdateRoomType;

public class UpdateRoomTypeHandler : IRequestHandler<UpdateRoomTypeCommand>
{
    private readonly IRoomTypeRepository _repository;

    public UpdateRoomTypeHandler(IRoomTypeRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(
        UpdateRoomTypeCommand request,
        CancellationToken cancellationToken)
    {
        var roomType = await _repository.GetByIdAsync(request.Id);

        if (roomType is null)
            throw new KeyNotFoundException("Room type not found.");

        roomType.Name = request.Name.Trim();
        roomType.Description = request.Description?.Trim();
        roomType.BasePricePerNight = request.BasePricePerNight;
        roomType.MaxOccupancy = request.MaxOccupancy;

         await _repository.UpdateAsync(roomType);
    }
}