using HotelManagementSystem.Domain.Entities;

namespace HotelManagementSystem.Application.Abstractions.Persistence;

public interface IDepartmentRepository
{
    Task<Department?> GetByIdAsync(int id);

    Task<IEnumerable<Department>> GetAllAsync();

    Task AddAsync(Department department);

    void Update(Department department);

    void Delete(Department department);
}