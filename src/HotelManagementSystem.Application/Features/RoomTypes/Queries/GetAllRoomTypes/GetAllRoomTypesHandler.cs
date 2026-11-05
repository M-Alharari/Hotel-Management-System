using HotelManagementSystem.Application.Abstractions.Persistence;
using HotelManagementSystem.Application.Features.RoomTypes.Responses;
using MediatR;

namespace HotelManagementSystem.Application.Features.RoomTypes.Queries.GetAllRoomTypes;

public class GetAllRoomTypesHandler
    : IRequestHandler<GetAllRoomTypesQuery, IEnumerable<RoomTypeResponse>>
{
    private readonly IRoomTypeRepository _repository;

    public GetAllRoomTypesHandler(IRoomTypeRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<RoomTypeResponse>> Handle(
        GetAllRoomTypesQuery request,
        CancellationToken cancellationToken)
    {
        var roomTypes = await _repository.GetAllAsync();

        return roomTypes.Select(roomType => new RoomTypeResponse
        {
            Id = roomType.Id,
            Name = roomType.Name,
            Description = roomType.Description,
            BasePricePerNight = roomType.BasePricePerNight,
            MaxOccupancy = roomType.MaxOccupancy,
            IsActive = roomType.IsActive
        });
    }
}