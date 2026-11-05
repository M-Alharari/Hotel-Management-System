using HotelManagementSystem.Application.Abstractions.Persistence;
using HotelManagementSystem.Application.Features.Payments.Responses;
using HotelManagementSystem.Application.Mapping;
using MediatR;

namespace HotelManagementSystem.Application.Features.Payments.Queries.GetPaymentsByReservation;

public class GetPaymentsByReservationHandler
    : IRequestHandler<GetPaymentsByReservationQuery, IEnumerable<PaymentResponse>>
{
    private readonly IPaymentRepository _repository;

    public GetPaymentsByReservationHandler(IPaymentRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<PaymentResponse>> Handle(
        GetPaymentsByReservationQuery request,
        CancellationToken cancellationToken)
    {
        var payments = await _repository
            .GetByReservationIdAsync(request.ReservationId);

        return payments.Select(p => p.ToResponse());
    }
}