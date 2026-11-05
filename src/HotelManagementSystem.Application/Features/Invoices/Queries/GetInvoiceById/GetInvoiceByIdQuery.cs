using HotelManagementSystem.Application.Features.Invoices.Responses;
using MediatR;

namespace HotelManagementSystem.Application.Features.Invoices.Queries.GetInvoiceById;

public record GetInvoiceByIdQuery(int Id) : IRequest<InvoiceResponse?>;