using HotelManagementSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Reflection;
using System.Text;

namespace HotelManagementSystem.Domain.Entities
{
    public class Person
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;

        public DateOnly DateOfBirth { get; set; }
        public Gender? Gender { get; set; }

        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;

        public string Address { get; set; } = null!;

        public int CountryId { get; set; }
        public Country Country { get; set; } = null!;
        public Guest? Guest { get; set; }
    }
}
