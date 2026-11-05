using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagementSystem.Domain.Entities
{
    
    public class User
    {
        public int Id { get; set; }

        public int PersonId { get; set; }
        public Person Person { get; set; } = null!;

        public string Username { get; set; } = null!;

        public string PasswordHash { get; set; } = null!;

        public bool IsActive { get; set; } = true;

        public DateTime? LastLoginAt { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
            = new List<UserRole>();
    }
}
