using HotelManagementSystem.Application.Abstractions.Persistence;
using HotelManagementSystem.Domain.Enums;
using MediatR;

namespace HotelManagementSystem.Application.Features.Invoices.Commands.VoidInvoice;

public class VoidInvoiceHandler
    : IRequestHandler<VoidInvoiceCommand, bool>
{
    private readonly IInvoiceRepository _repository;

    public VoidInvoiceHandler(IInvoiceRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(
        VoidInvoiceCommand request,
        CancellationToken cancellationToken)
    {
        var invoice = await _repository.GetByIdAsync(request.Id);

        if (invoice is null)
            throw new KeyNotFoundException("Invoice not found.");

        if (invoice.Status != InvoiceStatus.Issued)
            throw new InvalidOperationException(
                "Only issued invoices can be voided.");

        if (invoice.PaymentAllocations.Any())
            throw new InvalidOperationException(
                "An invoice with payment allocations cannot be voided.");

        invoice.Status = InvoiceStatus.Void;

        await _repository.UpdateAsync(invoice);

        return true;
    }
}