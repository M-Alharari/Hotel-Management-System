using HotelManagementSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagementSystem.Domain.Entities
{
    

    public class Payment
    {
        public int Id { get; set; }

        public int ReservationId { get; set; }
        public Reservation Reservation { get; set; } = null!;

        public decimal Amount { get; set; }

        public PaymentMethod Method { get; set; }

        public PaymentStatus Status { get; set; }

        public string? TransactionReference { get; set; }

        public DateTime? ReceivedAt { get; set; }

        public DateTime CreatedAt { get; set; }

        public ICollection<PaymentAllocation> PaymentAllocation { get; set; }
     = new List<PaymentAllocation>();
    }
}
