using HotelManagementSystem.Application.Abstractions.Persistence;
using HotelManagementSystem.Application.Features.Invoices.Responses;
using HotelManagementSystem.Application.Mapping;
using MediatR;

namespace HotelManagementSystem.Application.Features.Invoices.Queries.GetInvoiceById;

public class GetInvoiceByIdHandler
    : IRequestHandler<GetInvoiceByIdQuery, InvoiceResponse?>
{
    private readonly IInvoiceRepository _repository;

    public GetInvoiceByIdHandler(IInvoiceRepository repository)
    {
        _repository = repository;
    }

    public async Task<InvoiceResponse?> Handle(
        GetInvoiceByIdQuery request,
        CancellationToken cancellationToken)
    {
        var invoice = await _repository.GetByIdAsync(request.Id);

        return invoice?.ToResponse();
    }
}