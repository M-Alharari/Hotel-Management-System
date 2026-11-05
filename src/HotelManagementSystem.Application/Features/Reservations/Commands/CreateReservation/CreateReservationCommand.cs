using MediatR;

namespace HotelManagementSystem.Application.Features.Reservations.Commands.CreateReservation;

public class CreateReservationCommand : IRequest<int>
{
    public int PrimaryGuestId { get; set; }

    public DateOnly CheckInDate { get; set; }

    public DateOnly CheckOutDate { get; set; }

    public string? SpecialRequests { get; set; }

    public List<ReservationRoomRequest> Rooms { get; set; } = new();
}