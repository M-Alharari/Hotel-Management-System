using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagementSystem.Domain.Entities
{
    public class RoomType
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public decimal BasePricePerNight { get; set; }

        public int MaxOccupancy { get; set; }

        public bool IsActive { get; set; }

        public ICollection<Room> Rooms { get; set; }
            = new List<Room>();
    }
}
