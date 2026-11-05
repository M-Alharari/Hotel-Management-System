namespace HotelManagementSystem.Application.Features.ServiceUsages.Models;

public class ServiceUsageResponse
{
    public int Id { get; set; }

    public int ReservationId { get; set; }

    public int HotelServiceId { get; set; }

    public string ServiceName { get; set; } = null!;

    public int Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    public decimal TotalPrice { get; set; }

    public DateTime UsedAt { get; set; }
}