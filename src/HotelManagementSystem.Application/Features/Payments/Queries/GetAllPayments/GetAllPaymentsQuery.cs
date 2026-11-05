using HotelManagementSystem.Application.Features.Payments.Responses;
using MediatR;

namespace HotelManagementSystem.Application.Features.Payments.Queries.GetAllPayments;

public record GetAllPaymentsQuery
    : IRequest<IEnumerable<PaymentResponse>>;