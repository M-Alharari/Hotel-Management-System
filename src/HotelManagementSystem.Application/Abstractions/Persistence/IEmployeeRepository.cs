using HotelManagementSystem.Domain.Entities;

namespace HotelManagementSystem.Application.Abstractions.Persistence;

public interface IEmployeeRepository
{
    Task<Employee?> GetByIdAsync(int id);

    Task<IEnumerable<Employee>> GetAllAsync();

    Task AddAsync(Employee employee);

    void Update(Employee employee);

    void Delete(Employee employee);
}