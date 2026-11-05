using HotelManagementSystem.Domain.Entities;

namespace HotelManagementSystem.Application.Abstractions.Persistence;

public interface IRoleRepository
{
    Task<Role?> GetByIdAsync(int id);
    Task<Role?> GetByNameAsync(string name);
    Task<IEnumerable<Role>> GetAllAsync();

    Task AddAsync(Role role);
    void Update(Role role);
    void Delete(Role role);
}