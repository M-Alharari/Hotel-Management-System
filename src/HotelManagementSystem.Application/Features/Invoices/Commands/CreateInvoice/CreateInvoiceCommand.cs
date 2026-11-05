using MediatR;

namespace HotelManagementSystem.Application.Features.Invoices.Commands.CreateInvoice;

public record CreateInvoiceCommand(int ReservationId) : IRequest<int>;