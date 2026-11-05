using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagementSystem.Domain.Entities
{
    public class Employee
    {
        public int Id { get; set; }

        public int PersonId { get; set; }
        public Person Person { get; set; } = null!;

        public int DepartmentId { get; set; }
        public Department Department { get; set; } = null!;

        public DateOnly HireDate { get; set; }

        public string JobTitle { get; set; } = null!;

        public bool IsActive { get; set; }
    }
}
