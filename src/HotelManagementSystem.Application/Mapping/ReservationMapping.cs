using HotelManagementSystem.Application.Features.Reservations.Commands.CreateReservation;
using HotelManagementSystem.Application.Features.Reservations.Responses;
using HotelManagementSystem.Domain.Entities;
using HotelManagementSystem.Domain.Enums;

namespace HotelManagementSystem.Application.Mapping;

public static class ReservationMapping
{
    public static Reservation ToEntity(
        this CreateReservationCommand request,
        DateTime now)
    {
        return new Reservation
        {
            PrimaryGuestId = request.PrimaryGuestId,
            CheckInDate = request.CheckInDate,
            CheckOutDate = request.CheckOutDate,
            SpecialRequests = request.SpecialRequests?.Trim(),

            Status = ReservationStatus.Pending,
            HoldExpiresAt = now.AddMinutes(30),

            CreatedAt = now
        };
    }

    public static ReservationRoom ToEntity(
        this ReservationRoomRequest request,
        decimal pricePerNight)
    {
        return new ReservationRoom
        {
            RoomId = request.RoomId,
            Adults = request.Adults,
            Children = request.Children,
            PricePerNight = pricePerNight
        };
    }

    public static ReservationResponse ToResponse(this Reservation reservation)
    {
        return new ReservationResponse
        {
            Id = reservation.Id,
            PrimaryGuestId = reservation.PrimaryGuestId,
            CheckInDate = reservation.CheckInDate,
            CheckOutDate = reservation.CheckOutDate,
            SpecialRequests = reservation.SpecialRequests,
            Status = reservation.Status,
            HoldExpiresAt = reservation.HoldExpiresAt,
            CreatedAt = reservation.CreatedAt
            // Add any other properties or child collections (e.g. Rooms) as defined in your ReservationResponse
        };
    }
}