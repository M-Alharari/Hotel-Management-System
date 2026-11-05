using HotelManagementSystem.Domain.Entities;

namespace HotelManagementSystem.Application.Abstractions.Persistence;

public interface ICountryRepository
{
    Task<Country?> GetByIdAsync(int id);

    Task<IEnumerable<Country>> GetAllAsync();

    Task AddAsync(Country country);

    void Update(Country country);

    void Delete(Country country);
}