using HotelManagementSystem.Application.Abstractions.Persistence;
using HotelManagementSystem.Application.Features.Payments.Responses;
using HotelManagementSystem.Application.Mapping;
using MediatR;

namespace HotelManagementSystem.Application.Features.Payments.Queries.GetAllPayments;

public class GetAllPaymentsHandler
    : IRequestHandler<GetAllPaymentsQuery, IEnumerable<PaymentResponse>>
{
    private readonly IPaymentRepository _repository;

    public GetAllPaymentsHandler(IPaymentRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<PaymentResponse>> Handle(
        GetAllPaymentsQuery request,
        CancellationToken cancellationToken)
    {
        var payments = await _repository.GetAllAsync();

        return payments.Select(p => p.ToResponse());
    }
}