namespace HotelManagementSystem.Application.Features.Invoices.Responses;

public class InvoiceLineResponse
{
    public int Id { get; set; }

    public string Description { get; set; } = null!;

    public decimal Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    public decimal LineTotal { get; set; }
}