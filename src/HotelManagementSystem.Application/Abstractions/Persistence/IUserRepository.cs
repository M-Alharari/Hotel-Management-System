using HotelManagementSystem.Domain.Entities;

namespace HotelManagementSystem.Application.Abstractions.Persistence;

public interface IUserRepository
{
    Task<User?> GetByIdAsync(int id);
    Task<User?> GetByUsernameAsync(string username);
    Task<IEnumerable<User>> GetAllAsync();

    Task AddAsync(User user);
    void Update(User user);
    void Delete(User user);
}