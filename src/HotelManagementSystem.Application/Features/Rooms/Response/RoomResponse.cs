using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagementSystem.Application.Features.Rooms.Response
{
    public class RoomResponse
    {
        public int Id { get; set; }
        public string RoomNumber { get; set; } = null!;
        public string RoomTypeName { get; set; } = null!;
        public decimal BasePricePerNight { get; set; }
    }
}
