using HotelManagementSystem.Application.Abstractions.Persistence;
using HotelManagementSystem.Domain.Enums;
using MediatR;

namespace HotelManagementSystem.Application.Features.Payments.Commands.ChangePaymentStatus;

public class ChangePaymentStatusHandler
    : IRequestHandler<ChangePaymentStatusCommand, bool>
{
    private readonly IPaymentRepository _repository;

    public ChangePaymentStatusHandler(IPaymentRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(
        ChangePaymentStatusCommand request,
        CancellationToken cancellationToken)
    {
        var payment = await _repository.GetByIdAsync(request.Id);

        if (payment is null)
            throw new KeyNotFoundException("Payment not found.");

        if (payment.Status != PaymentStatus.Pending)
            throw new InvalidOperationException(
                "Only pending payments can change status.");

        payment.Status = request.Status;

        if (request.Status == PaymentStatus.Succeeded)
            payment.ReceivedAt = DateTime.UtcNow;

        await _repository.UpdateAsync(payment);

        return true;
    }
}