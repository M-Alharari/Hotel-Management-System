using HotelManagementSystem.Domain.Entities;

namespace HotelManagementSystem.Application.Abstractions.Persistence;

public interface IInvoiceRepository
{
    Task<Invoice?> GetByIdAsync(int id);

    Task<IEnumerable<Invoice>> GetAllAsync();

    Task<IEnumerable<Invoice>> GetByReservationIdAsync(int reservationId);

    Task AddAsync(Invoice invoice);

    Task UpdateAsync(Invoice invoice);
}