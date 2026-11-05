using HotelManagementSystem.Application.Abstractions.Persistence;
using HotelManagementSystem.Application.Features.Payments.Responses;
using HotelManagementSystem.Application.Mapping;
using MediatR;

namespace HotelManagementSystem.Application.Features.Payments.Queries.GetPaymentById;

public class GetPaymentByIdHandler
    : IRequestHandler<GetPaymentByIdQuery, PaymentResponse?>
{
    private readonly IPaymentRepository _repository;

    public GetPaymentByIdHandler(IPaymentRepository repository)
    {
        _repository = repository;
    }

    public async Task<PaymentResponse?> Handle(
        GetPaymentByIdQuery request,
        CancellationToken cancellationToken)
    {
        var payment = await _repository.GetByIdAsync(request.Id);

        return payment?.ToResponse();
    }
}