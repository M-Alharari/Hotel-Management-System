using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagementSystem.Domain.Entities
{
    public class Country
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string CountryCode { get; set; } = null!;

        public ICollection<Person> Residents { get; set; } = new List<Person>();

        public ICollection<Guest> Guests { get; set; } = new List<Guest>();
    }
}
