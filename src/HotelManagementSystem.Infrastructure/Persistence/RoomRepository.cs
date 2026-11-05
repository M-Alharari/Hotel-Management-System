using HotelManagementSystem.Application.Abstractions.Persistence;
using HotelManagementSystem.Domain.Entities;
using HotelManagementSystem.Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementSystem.Infrastructure.Persistence.Repositories;

public class RoomRepository : IRoomRepository
{
    private readonly AppDbContext _context;

    public RoomRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Room?> GetByIdAsync(int id)
    {
        return await _context.Rooms
            .Include(r => r.RoomType)
            .FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task<IEnumerable<Room>> GetAllAsync()
    {
        return await _context.Rooms
            .Include(r => r.RoomType)
            .ToListAsync();
    }

    public async Task AddAsync(Room room)
    {
        await _context.Rooms.AddAsync(room);
        await _context.SaveChangesAsync();
    }

    public void Update(Room room)
    {
        _context.Rooms.Update(room);
    }

    public void Delete(Room room)
    {
        _context.Rooms.Remove(room);
    }
}