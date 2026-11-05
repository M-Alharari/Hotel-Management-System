using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagementSystem.Domain.Entities
{
    public class PaymentAllocation
    {
        public int Id { get; set; }

        public int PaymentId { get; set; }
        public Payment Payment { get; set; } = null!;

        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; } = null!;

        public decimal Amount { get; set; }

        public DateTime AllocatedAt { get; set; }
    }
}
