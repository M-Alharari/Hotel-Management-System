using HotelManagementSystem.Domain.Entities;

namespace HotelManagementSystem.Application.Abstractions.Persistence;

public interface IServiceUsageRepository
{
    Task<ServiceUsage?> GetByIdAsync(int id);

    Task<IEnumerable<ServiceUsage>> GetAllAsync();

    Task AddAsync(ServiceUsage usage);
}