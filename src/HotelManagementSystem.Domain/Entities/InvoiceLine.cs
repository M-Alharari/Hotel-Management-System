using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagementSystem.Domain.Entities
{
    
    public class InvoiceLine
    {
        public int Id { get; set; }

        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; } = null!;

        public string Description { get; set; } = null!;

        public decimal Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public int? ReservationRoomId { get; set; }
        public ReservationRoom? ReservationRoom { get; set; }

        public int? ServiceUsageId { get; set; }
        public ServiceUsage? ServiceUsage { get; set; }
    }
}
