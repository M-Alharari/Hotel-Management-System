using MediatR;

namespace HotelManagementSystem.Application.Features.Invoices.Commands.VoidInvoice;

public record VoidInvoiceCommand(int Id) : IRequest<bool>;