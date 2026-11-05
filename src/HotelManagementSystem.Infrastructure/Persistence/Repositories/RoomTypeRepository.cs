using HotelManagementSystem.Application.Abstractions.Persistence;
using HotelManagementSystem.Domain.Entities;
using HotelManagementSystem.Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementSystem.Infrastructure.Persistence.Repositories;

public class RoomTypeRepository : IRoomTypeRepository
{
    private readonly AppDbContext _context;

    public RoomTypeRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<RoomType?> GetByIdAsync(int id)
    {
        return await _context.RoomTypes
            .FirstOrDefaultAsync(rt => rt.Id == id);
    }

    public async Task<IEnumerable<RoomType>> GetAllAsync()
    {
        return await _context.RoomTypes
            .ToListAsync();
    }
    public async Task<bool> ExistsByNameAsync(string name)
    {
        return await _context.RoomTypes
            .AnyAsync(rt => rt.Name == name);
    }
    public async Task AddAsync(RoomType roomType)
    {
        await _context.RoomTypes.AddAsync(roomType);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(RoomType roomType)
    {
        _context.RoomTypes.Update(roomType);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(RoomType roomType)
    {
        _context.RoomTypes.Remove(roomType);
        await _context.SaveChangesAsync();
    }
}