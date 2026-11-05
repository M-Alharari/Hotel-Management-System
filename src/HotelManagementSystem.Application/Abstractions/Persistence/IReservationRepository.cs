using HotelManagementSystem.Domain.Entities;

namespace HotelManagementSystem.Application.Abstractions.Persistence;

public interface IReservationRepository
{
    Task<Reservation?> GetByIdAsync(int id);

    Task<IEnumerable<Reservation>> GetAllAsync();

    Task AddAsync(Reservation reservation);

    Task UpdateAsync(Reservation reservation);

    Task<bool> IsRoomAvailableAsync(
        int roomId,
        DateOnly checkInDate,
        DateOnly checkOutDate,
        DateTime now,
        int? excludeReservationId = null);

    Task<Reservation?> GetForInvoiceAsync(int id);
}

