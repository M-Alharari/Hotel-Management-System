namespace HotelManagementSystem.Application.Features.Invoices.Responses;

public class InvoiceResponse
{
    public int Id { get; set; }

    public string InvoiceNumber { get; set; } = null!;

    public int ReservationId { get; set; }

    public decimal TotalAmount { get; set; }

    public decimal PaidAmount { get; set; }

    public decimal RemainingBalance { get; set; }

    public string Status { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime? IssuedAt { get; set; }

    public List<InvoiceLineResponse> InvoiceLines { get; set; }
        = new();
}