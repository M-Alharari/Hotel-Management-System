using HotelManagementSystem.Domain.Entities;

namespace HotelManagementSystem.Application.Abstractions.Persistence;

public interface IHotelServiceRepository
{
    Task<HotelService?> GetByIdAsync(int id);

    Task<IEnumerable<HotelService>> GetAllAsync();

    Task AddAsync(HotelService service);

    Task UpdateAsync(HotelService service);

    Task<bool> ExistsByNameAsync(
        string name,
        int? excludeId = null);
}