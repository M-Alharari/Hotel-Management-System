using HotelManagementSystem.Application.Abstractions.Persistence;
using HotelManagementSystem.Domain.Entities;
using HotelManagementSystem.Domain.Enums;
using MediatR;

namespace HotelManagementSystem.Application.Features.Payments.Commands.AllocatePayment;

public class AllocatePaymentHandler
    : IRequestHandler<AllocatePaymentCommand, int>
{
    private readonly IPaymentRepository _paymentRepository;
    private readonly IInvoiceRepository _invoiceRepository;
    private readonly IPaymentAllocationRepository _allocationRepository;

    public AllocatePaymentHandler(
        IPaymentRepository paymentRepository,
        IInvoiceRepository invoiceRepository,
        IPaymentAllocationRepository allocationRepository)
    {
        _paymentRepository = paymentRepository;
        _invoiceRepository = invoiceRepository;
        _allocationRepository = allocationRepository;
    }

    public async Task<int> Handle(
        AllocatePaymentCommand request,
        CancellationToken cancellationToken)
    {
        var payment = await _paymentRepository.GetByIdAsync(request.PaymentId);

        if (payment is null)
            throw new KeyNotFoundException("Payment not found.");

        var invoice = await _invoiceRepository.GetByIdAsync(request.InvoiceId);

        if (invoice is null)
            throw new KeyNotFoundException("Invoice not found.");

        if (payment.Status != PaymentStatus.Succeeded)
            throw new InvalidOperationException(
                "Only successful payments can be allocated.");

        if (invoice.Status != InvoiceStatus.Issued)
            throw new InvalidOperationException(
                "Only issued invoices can receive payments.");

        if (payment.ReservationId != invoice.ReservationId)
            throw new InvalidOperationException(
                "Payment and invoice must belong to the same reservation.");

        var allocatedPaymentAmount =
            payment.PaymentAllocation.Sum(x => x.Amount);

        var allocatedInvoiceAmount =
            invoice.PaymentAllocations.Sum(x => x.Amount);

        var paymentRemaining =
            payment.Amount - allocatedPaymentAmount;

        var invoiceRemaining =
            invoice.TotalAmount - allocatedInvoiceAmount;

        if (request.Amount > paymentRemaining)
            throw new InvalidOperationException(
                "Allocation exceeds the remaining payment amount.");

        if (request.Amount > invoiceRemaining)
            throw new InvalidOperationException(
                "Allocation exceeds the invoice balance.");

        var allocation = new PaymentAllocation
        {
            PaymentId = payment.Id,
            InvoiceId = invoice.Id,
            Amount = request.Amount,
            AllocatedAt = DateTime.UtcNow
        };

        await _allocationRepository.AddAsync(allocation);

        return allocation.Id;
    }
}