using HotelManagementSystem.Application.Abstractions.Persistence;
using HotelManagementSystem.Domain.Entities;
using HotelManagementSystem.Infrastructure.Persistence;
using HotelManagementSystem.Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementSystem.Infrastructure.Repositories;

public class PersonRepository : IPersonRepository
{
    private readonly AppDbContext _context;

    public PersonRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Person?> GetByIdAsync(int id)
    {
        return await _context.People
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task AddAsync(Person person)
    {
        await _context.People.AddAsync(person);

        await _context.SaveChangesAsync();
    }

    public void Update(Person person)
    {
        _context.People.Update(person);
    }

    public void Delete(Person person)
    {
        _context.People.Remove(person);
    }
}