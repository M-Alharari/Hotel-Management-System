using HotelManagementSystem.Application.Abstractions.Persistence;
using HotelManagementSystem.Domain.Entities;
using HotelManagementSystem.Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementSystem.Infrastructure.Persistence.Repositories;

public class GuestRepository : IGuestRepository
{
    private readonly AppDbContext _context;

    public GuestRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Guest?> GetByIdAsync(int id)
    {
        return await _context.Guests
            .Include(g => g.Person)
            
            .FirstOrDefaultAsync(g => g.Id == id);
    }

    public async Task<IEnumerable<Guest>> GetAllAsync()
    {
        return await _context.Guests
            .Include(g => g.Person)
            .Include(g => g.Nationality)
            .ToListAsync();
    }

    public async Task AddAsync(Guest guest)
    {
        await _context.Guests.AddAsync(guest);
        await _context.SaveChangesAsync();
    }

    public void Update(Guest guest)
    {
        _context.Guests.Update(guest);
    }

    public void Delete(Guest guest)
    {
        _context.Guests.Remove(guest);
    }
}