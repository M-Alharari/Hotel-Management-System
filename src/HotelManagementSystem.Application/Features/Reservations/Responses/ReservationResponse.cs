using HotelManagementSystem.Domain.Enums;

namespace HotelManagementSystem.Application.Features.Reservations.Responses;

public class ReservationResponse
{
    public int Id { get; set; }
    public int PrimaryGuestId { get; set; }
    public DateOnly CheckInDate { get; set; }
    public DateOnly CheckOutDate { get; set; }
    public ReservationStatus Status { get; set; }
    public DateTime? HoldExpiresAt { get; set; }
    public string? SpecialRequests { get; set; }
    public DateTime CreatedAt { get; set; }

    public decimal TotalPrice =>
        Rooms.Sum(r => r.Subtotal);

    public List<ReservationRoomResponse> Rooms { get; set; } = new();
}

public class ReservationRoomResponse
{
    public int RoomId { get; set; }
    public string RoomNumber { get; set; } = null!;
    public string RoomTypeName { get; set; } = null!;
    public decimal PricePerNight { get; set; }
    public int Adults { get; set; }
    public int Children { get; set; }
    public decimal Subtotal { get; set; }
}