using HotelManagementSystem.Application.Abstractions.Persistence;
using HotelManagementSystem.Domain.Entities;
using HotelManagementSystem.Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementSystem.Infrastructure.Persistence.Repositories;

public class InvoiceRepository : IInvoiceRepository
{
    private readonly AppDbContext _context;

    public InvoiceRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Invoice?> GetByIdAsync(int id)
    {
        return await _context.Invoices
            .Include(i => i.InvoiceLines)
            .Include(i => i.PaymentAllocations)
            .FirstOrDefaultAsync(i => i.Id == id);
    }

    public async Task<IEnumerable<Invoice>> GetAllAsync()
    {
        return await _context.Invoices
            .AsNoTracking()
            .Include(i => i.InvoiceLines)
            .Include(i => i.PaymentAllocations)
            .ToListAsync();
    }

    public async Task<IEnumerable<Invoice>> GetByReservationIdAsync(
        int reservationId)
    {
        return await _context.Invoices
            .AsNoTracking()
            .Where(i => i.ReservationId == reservationId)
            .Include(i => i.InvoiceLines)
            .Include(i => i.PaymentAllocations)
            .ToListAsync();
    }

    public async Task AddAsync(Invoice invoice)
    {
        await _context.Invoices.AddAsync(invoice);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Invoice invoice)
    {
        _context.Invoices.Update(invoice);
        await _context.SaveChangesAsync();
    }
}