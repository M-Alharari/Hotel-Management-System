using HotelManagementSystem.Application.Abstractions.Persistence;
using HotelManagementSystem.Domain.Entities;
using HotelManagementSystem.Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementSystem.Infrastructure.Persistence.Repositories;

public class CountryRepository : ICountryRepository
{
    private readonly AppDbContext _context;

    public CountryRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Country?> GetByIdAsync(int id)
    {
        return await _context.Countries
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<IEnumerable<Country>> GetAllAsync()
    {
        return await _context.Countries
            .ToListAsync();
    }

    public async Task AddAsync(Country country)
    {
        await _context.Countries.AddAsync(country); await _context.SaveChangesAsync();
    }

    public void Update(Country country)
    {
        _context.Countries.Update(country);
    }

    public void Delete(Country country)
    {
        _context.Countries.Remove(country);
    }
}