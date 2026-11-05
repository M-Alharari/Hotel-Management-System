using HotelManagementSystem.Domain.Enums;

namespace HotelManagementSystem.Domain.Entities;

public class Invoice
{
    public int Id { get; set; }

    public string InvoiceNumber { get; set; } = null!;

    public int ReservationId { get; set; }
    public Reservation Reservation { get; set; } = null!;

    public decimal TotalAmount { get; set; }

    public InvoiceStatus Status { get; set; } = InvoiceStatus.Draft;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime? IssuedAt { get; set; }

    public ICollection<PaymentAllocation> PaymentAllocations { get; set; }
        = new List<PaymentAllocation>();

    public ICollection<InvoiceLine> InvoiceLines { get; set; }
    = new List<InvoiceLine>();
}