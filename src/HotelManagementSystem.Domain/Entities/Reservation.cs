using HotelManagementSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagementSystem.Domain.Entities
{
    public class Reservation
    {
        public int Id { get; set; }

        public int PrimaryGuestId { get; set; }
        public Guest PrimaryGuest { get; set; } = null!;

        public DateOnly CheckInDate { get; set; }
        public DateOnly CheckOutDate { get; set; }

        public ReservationStatus Status { get; set; }

        public DateTime? HoldExpiresAt { get; set; }

        public string? SpecialRequests { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public int? CreatedByUserId { get; set; }
        public User? CreatedByUser { get; set; }

        public ICollection<ReservationRoom> ReservationRooms { get; set; }
            = new List<ReservationRoom>();

        public ICollection<Payment> Payments { get; set; }
    = new List<Payment>();

        public ICollection<Invoice> Invoices { get; set; }
            = new List<Invoice>();


        public ICollection<ServiceUsage> ServiceUsages { get; set; }
                = new List<ServiceUsage>();
    }
}
