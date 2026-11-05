using HotelManagementSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagementSystem.Domain.Entities
{
    public class Room
    {
        public int Id { get; set; }

      
        public HotelService Hotel { get; set; } = null!;

        public int RoomTypeId { get; set; }
        public RoomType RoomType { get; set; } = null!;

        public string RoomNumber { get; set; } = null!;

        public int Floor { get; set; }

        public RoomStatus Status { get; set; }

        public ICollection<ReservationRoom> ReservationRooms { get; set; }
            = new List<ReservationRoom>();
    }
}
