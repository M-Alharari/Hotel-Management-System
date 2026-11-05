using HotelManagementSystem.Domain.Enums;

namespace HotelManagementSystem.Application.Features.Payments.Responses;

public class PaymentResponse
{
    public int Id { get; set; }
    public int ReservationId { get; set; }
    public decimal Amount { get; set; }
    public string Method { get; set; } = null!;
    public string Status { get; set; } = null!;
    public string? TransactionReference { get; set; }
    public DateTime? ReceivedAt { get; set; }
    public DateTime CreatedAt { get; set; }
}