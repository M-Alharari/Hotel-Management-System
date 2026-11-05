using HotelManagementSystem.Domain.Entities;

namespace HotelManagementSystem.Application.Abstractions.Persistence;

public interface IPaymentRepository
{
    Task<Payment?> GetByIdAsync(int id);

    Task<IEnumerable<Payment>> GetAllAsync();

    Task<IEnumerable<Payment>> GetByReservationIdAsync(int reservationId);

    Task AddAsync(Payment payment);

    Task UpdateAsync(Payment payment);
}