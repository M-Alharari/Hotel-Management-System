using HotelManagementSystem.Application.Features.Payments.Responses;
using MediatR;

namespace HotelManagementSystem.Application.Features.Payments.Queries.GetPaymentsByReservation;

public record GetPaymentsByReservationQuery(int ReservationId)
    : IRequest<IEnumerable<PaymentResponse>>;