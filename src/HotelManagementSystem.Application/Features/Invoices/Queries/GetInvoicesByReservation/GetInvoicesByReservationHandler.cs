using HotelManagementSystem.Application.Abstractions.Persistence;
using HotelManagementSystem.Application.Features.Invoices.Responses;
using HotelManagementSystem.Application.Mapping;
using MediatR;

namespace HotelManagementSystem.Application.Features.Invoices.Queries.GetInvoicesByReservation;

public class GetInvoicesByReservationHandler
    : IRequestHandler<GetInvoicesByReservationQuery, IEnumerable<InvoiceResponse>>
{
    private readonly IInvoiceRepository _repository;

    public GetInvoicesByReservationHandler(IInvoiceRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<InvoiceResponse>> Handle(
        GetInvoicesByReservationQuery request,
        CancellationToken cancellationToken)
    {
        var invoices = await _repository
            .GetByReservationIdAsync(request.ReservationId);

        return invoices.Select(x => x.ToResponse());
    }
}