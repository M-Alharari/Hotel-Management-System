using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagementSystem.Domain.Enums
{
    public enum ReservationStatus
    {
        Pending = 1,
        Confirmed = 2,
        CheckedIn = 3,
        CheckedOut = 4,
        Cancelled = 5,
        NoShow = 6
    }
}
