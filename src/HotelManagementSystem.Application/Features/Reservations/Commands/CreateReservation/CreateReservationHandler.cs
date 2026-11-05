using HotelManagementSystem.Application.Abstractions.Persistence;
using HotelManagementSystem.Application.Mapping;
using MediatR;

namespace HotelManagementSystem.Application.Features.Reservations.Commands.CreateReservation;

public class CreateReservationHandler
    : IRequestHandler<CreateReservationCommand, int>
{
    private readonly IReservationRepository _reservationRepository;
    private readonly IGuestRepository _guestRepository;
    private readonly IRoomRepository _roomRepository;

    public CreateReservationHandler(
        IReservationRepository reservationRepository,
        IGuestRepository guestRepository,
        IRoomRepository roomRepository)
    {
        _reservationRepository = reservationRepository;
        _guestRepository = guestRepository;
        _roomRepository = roomRepository;
    }

    public async Task<int> Handle(
     CreateReservationCommand request,
     CancellationToken cancellationToken)
    {
        var now = DateTime.UtcNow;
        var today = DateOnly.FromDateTime(now);

        // Validate dates
        if (request.CheckInDate < today)
            throw new InvalidOperationException(
                "Check-in date cannot be in the past.");

        if (request.CheckOutDate <= request.CheckInDate)
            throw new InvalidOperationException(
                "Check-out date must be after check-in date.");

        // Validate primary guest
        var guest = await _guestRepository.GetByIdAsync(
            request.PrimaryGuestId);

        if (guest == null)
            throw new KeyNotFoundException("Guest was not found.");

        // Map reservation
        var reservation = request.ToEntity(now);

        // Validate and map rooms
        foreach (var roomRequest in request.Rooms)
        {
            var room = await _roomRepository.GetByIdAsync(
                roomRequest.RoomId);

            if (room == null)
                throw new KeyNotFoundException(
                    $"Room {roomRequest.RoomId} was not found.");

            if (!room.RoomType.IsActive)
                throw new InvalidOperationException(
                    $"Room {room.RoomNumber} belongs to an inactive room type.");

            var totalGuests = roomRequest.Adults + roomRequest.Children;

            if (totalGuests > room.RoomType.MaxOccupancy)
                throw new InvalidOperationException(
                    $"Room {room.RoomNumber} exceeds its maximum occupancy.");

            var isAvailable =
                await _reservationRepository.IsRoomAvailableAsync(
                    room.Id,
                    request.CheckInDate,
                    request.CheckOutDate,
                    now);

            if (!isAvailable)
                throw new InvalidOperationException(
                    $"Room {room.RoomNumber} is not available for the selected dates.");

            if (room.RoomType.BasePricePerNight <= 0)
                throw new InvalidOperationException(
                    $"Room {room.RoomNumber} has an invalid price.");

            var reservationRoom = roomRequest.ToEntity(
                room.RoomType.BasePricePerNight);

            reservation.ReservationRooms.Add(reservationRoom);
        }

        // Save reservation
        await _reservationRepository.AddAsync(reservation);

        return reservation.Id;
    }
}