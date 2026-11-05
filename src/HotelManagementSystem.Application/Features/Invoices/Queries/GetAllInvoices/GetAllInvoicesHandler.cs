using HotelManagementSystem.Application.Abstractions.Persistence;
using HotelManagementSystem.Application.Features.Invoices.Responses;
using HotelManagementSystem.Application.Mapping;
using MediatR;

namespace HotelManagementSystem.Application.Features.Invoices.Queries.GetAllInvoices;

public class GetAllInvoicesHandler
    : IRequestHandler<GetAllInvoicesQuery, IEnumerable<InvoiceResponse>>
{
    private readonly IInvoiceRepository _repository;

    public GetAllInvoicesHandler(IInvoiceRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<InvoiceResponse>> Handle(
        GetAllInvoicesQuery request,
        CancellationToken cancellationToken)
    {
        var invoices = await _repository.GetAllAsync();

        return invoices.Select(x => x.ToResponse());
    }
}