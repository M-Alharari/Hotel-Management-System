using HotelManagementSystem.Domain.Entities;

namespace HotelManagementSystem.Application.Abstractions.Persistence;

public interface IRoomRepository
{
    Task<Room?> GetByIdAsync(int id);
    Task<IEnumerable<Room>> GetAllAsync();

    Task AddAsync(Room room);
    void Update(Room room);
    void Delete(Room room);
}