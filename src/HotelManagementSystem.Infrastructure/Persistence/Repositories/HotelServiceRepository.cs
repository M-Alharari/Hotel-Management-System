using HotelManagementSystem.Application.Abstractions.Persistence;
using HotelManagementSystem.Domain.Entities;
using HotelManagementSystem.Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementSystem.Infrastructure.Persistence.Repositories;

public class HotelServiceRepository : IHotelServiceRepository
{
    private readonly AppDbContext _context;

    public HotelServiceRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<HotelService?> GetByIdAsync(int id)
    {
        return await _context.HotelServices
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<HotelService>> GetAllAsync()
    {
        return await _context.HotelServices
            .AsNoTracking()
            .OrderBy(x => x.Name)
            .ToListAsync();
    }

    public async Task AddAsync(HotelService service)
    {
        await _context.HotelServices.AddAsync(service);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(HotelService service)
    {
        _context.HotelServices.Update(service);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> ExistsByNameAsync(
        string name,
        int? excludeId = null)
    {
        return await _context.HotelServices.AnyAsync(x =>
            x.Name == name &&
            (!excludeId.HasValue || x.Id != excludeId.Value));
    }
}