using HotelManagementSystem.Application.Abstractions.Persistence;
using HotelManagementSystem.Domain.Entities;
using HotelManagementSystem.Domain.Enums;
using HotelManagementSystem.Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementSystem.Infrastructure.Persistence.Repositories;

public class ReservationRepository : IReservationRepository
{
    private readonly AppDbContext _context;

    public ReservationRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Reservation?> GetByIdAsync(int id)
    {
        return await _context.Reservations
            .Include(r => r.PrimaryGuest)
                .ThenInclude(g => g.Person)
            .Include(r => r.ReservationRooms)
                .ThenInclude(rr => rr.Room)
                    .ThenInclude(room => room.RoomType)
            .FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task<IEnumerable<Reservation>> GetAllAsync()
    {
        return await _context.Reservations
            .Include(r => r.PrimaryGuest)
                .ThenInclude(g => g.Person)
            .Include(r => r.ReservationRooms)
                .ThenInclude(rr => rr.Room)
                    .ThenInclude(room => room.RoomType)
            .ToListAsync();
    }

    public async Task AddAsync(Reservation reservation)
    {
        await _context.Reservations.AddAsync(reservation);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Reservation reservation)
    {
        _context.Reservations.Update(reservation);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> IsRoomAvailableAsync(
        int roomId,
        DateOnly checkInDate,
        DateOnly checkOutDate,
        DateTime now,
        int? excludeReservationId = null)
    {
        return !await _context.Reservations.AnyAsync(r =>
      (!excludeReservationId.HasValue ||
       r.Id != excludeReservationId.Value) &&

      r.ReservationRooms.Any(rr => rr.RoomId == roomId) &&

      r.CheckInDate < checkOutDate &&
      r.CheckOutDate > checkInDate &&

      (r.Status == ReservationStatus.Confirmed ||
       r.Status == ReservationStatus.CheckedIn ||
       (r.Status == ReservationStatus.Pending &&
        r.HoldExpiresAt > now))
  );
    }


    public async Task<Reservation?> GetForInvoiceAsync(int id)
    {
        return await _context.Reservations
            .AsNoTracking()
            .Include(r => r.ReservationRooms)
                .ThenInclude(rr => rr.Room)
            .Include(r => r.ServiceUsages)
                .ThenInclude(su => su.HotelService)
            .FirstOrDefaultAsync(r => r.Id == id);
    }
}