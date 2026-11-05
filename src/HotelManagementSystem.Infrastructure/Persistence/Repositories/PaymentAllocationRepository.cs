using HotelManagementSystem.Application.Abstractions.Persistence;
using HotelManagementSystem.Domain.Entities;
using HotelManagementSystem.Infrastructure.Persistence.Data;

namespace HotelManagementSystem.Infrastructure.Persistence.Repositories;

public class PaymentAllocationRepository : IPaymentAllocationRepository
{
    private readonly AppDbContext _context;

    public PaymentAllocationRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(PaymentAllocation allocation)
    {
        await _context.PaymentAllocations.AddAsync(allocation);
        await _context.SaveChangesAsync();
    }
}