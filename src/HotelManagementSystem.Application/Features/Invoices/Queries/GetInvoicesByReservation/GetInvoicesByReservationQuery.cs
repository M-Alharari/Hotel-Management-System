using HotelManagementSystem.Application.Features.Invoices.Responses;
using MediatR;

namespace HotelManagementSystem.Application.Features.Invoices.Queries.GetInvoicesByReservation;

public record GetInvoicesByReservationQuery(int ReservationId)
    : IRequest<IEnumerable<InvoiceResponse>>;