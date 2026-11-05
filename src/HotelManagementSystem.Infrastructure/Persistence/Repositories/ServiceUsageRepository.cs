using HotelManagementSystem.Application.Abstractions.Persistence;
using HotelManagementSystem.Domain.Entities;
using HotelManagementSystem.Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementSystem.Infrastructure.Persistence.Repositories;

public class ServiceUsageRepository : IServiceUsageRepository
{
    private readonly AppDbContext _context;

    public ServiceUsageRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ServiceUsage?> GetByIdAsync(int id)
    {
        return await _context.ServiceUsages
            .AsNoTracking()
            .Include(x => x.HotelService)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<ServiceUsage>> GetAllAsync()
    {
        return await _context.ServiceUsages
            .AsNoTracking()
            .Include(x => x.HotelService)
            .OrderByDescending(x => x.UsedAt)
            .ToListAsync();
    }

    public async Task AddAsync(ServiceUsage usage)
    {
        await _context.ServiceUsages.AddAsync(usage);
        await _context.SaveChangesAsync();
    }
}