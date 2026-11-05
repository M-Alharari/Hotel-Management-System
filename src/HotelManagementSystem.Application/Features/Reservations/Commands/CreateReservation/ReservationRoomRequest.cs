namespace HotelManagementSystem.Application.Features.Reservations.Commands.CreateReservation;

public class ReservationRoomRequest
{
    public int RoomId { get; set; }

    public int Adults { get; set; }

    public int Children { get; set; }
}