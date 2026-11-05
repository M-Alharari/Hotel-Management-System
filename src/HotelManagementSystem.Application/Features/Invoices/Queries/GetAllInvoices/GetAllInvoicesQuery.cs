using HotelManagementSystem.Application.Features.Invoices.Responses;
using MediatR;

namespace HotelManagementSystem.Application.Features.Invoices.Queries.GetAllInvoices;

public record GetAllInvoicesQuery : IRequest<IEnumerable<InvoiceResponse>>;