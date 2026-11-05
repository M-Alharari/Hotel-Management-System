using HotelManagementSystem.Domain.Entities;

namespace HotelManagementSystem.Application.Abstractions.Persistence;

public interface IPaymentAllocationRepository
{
    Task AddAsync(PaymentAllocation allocation);
}