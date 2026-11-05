using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagementSystem.Domain.Enums
{
    public enum PaymentStatus
    {
        Pending = 1,
        Succeeded = 2,
        Failed = 3,
        Cancelled = 4
    }

    public enum PaymentMethod
    {
        Cash = 1,
        CreditCard = 2,
        BankTransfer = 3,
        Online = 4
    }
}
