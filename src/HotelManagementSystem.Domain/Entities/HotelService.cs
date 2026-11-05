using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagementSystem.Domain.Entities
{
   
    public class HotelService
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public bool IsActive { get; set; } = true;

        public ICollection<ServiceUsage> ServiceUsages { get; set; }
            = new List<ServiceUsage>();
    }
}
