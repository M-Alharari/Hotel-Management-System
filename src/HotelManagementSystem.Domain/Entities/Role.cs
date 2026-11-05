using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagementSystem.Domain.Entities
{
    public class Role
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
            = new List<UserRole>();
    }
}
