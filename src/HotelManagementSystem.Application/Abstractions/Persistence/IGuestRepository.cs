using HotelManagementSystem.Domain.Entities;

namespace HotelManagementSystem.Application.Abstractions.Persistence;

public interface IGuestRepository
{
    Task<Guest?> GetByIdAsync(int id);

    Task<IEnumerable<Guest>> GetAllAsync();

    Task AddAsync(Guest guest);

    void Update(Guest guest);

    void Delete(Guest guest);
}