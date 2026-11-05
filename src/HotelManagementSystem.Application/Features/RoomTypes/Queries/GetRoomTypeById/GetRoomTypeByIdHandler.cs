using HotelManagementSystem.Application.Abstractions.Persistence;
using HotelManagementSystem.Application.Features.RoomTypes.Responses;
using MediatR;

namespace HotelManagementSystem.Application.Features.RoomTypes.Queries.GetRoomTypeById;

public class GetRoomTypeByIdHandler
    : IRequestHandler<GetRoomTypeByIdQuery, RoomTypeResponse>
{
    private readonly IRoomTypeRepository _repository;

    public GetRoomTypeByIdHandler(IRoomTypeRepository repository)
    {
        _repository = repository;
    }

    public async Task<RoomTypeResponse> Handle(
        GetRoomTypeByIdQuery request,
        CancellationToken cancellationToken)
    {
        var roomType = await _repository.GetByIdAsync(request.Id);

        if (roomType is null)
            throw new KeyNotFoundException("Room type not found.");

        return new RoomTypeResponse
        {
            Id = roomType.Id,
            Name = roomType.Name,
            Description = roomType.Description,
            BasePricePerNight = roomType.BasePricePerNight,
            MaxOccupancy = roomType.MaxOccupancy,
            IsActive = roomType.IsActive
        };
    }
}