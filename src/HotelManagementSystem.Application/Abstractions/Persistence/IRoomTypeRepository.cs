using HotelManagementSystem.Domain.Entities;

namespace HotelManagementSystem.Application.Abstractions.Persistence;

public interface IRoomTypeRepository
{
    Task<RoomType?> GetByIdAsync(int id);
    Task<IEnumerable<RoomType>> GetAllAsync();
    Task<bool> ExistsByNameAsync(string name);
    Task AddAsync(RoomType roomType);
    Task UpdateAsync(RoomType roomType);
    Task DeleteAsync(RoomType roomType);
}