using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Text;

namespace HotelManagementSystem.Domain.Entities
{
    public class Guest
    {
        public int Id { get; set; }

        public int PersonId { get; set; }
        public Person Person { get; set; } = null!;

        public int NationalityId { get; set; }
        public Country Nationality { get; set; } = null!;
    }
}
