using HotelManagementSystem.Application.Features.Payments.Responses;
using MediatR;

namespace HotelManagementSystem.Application.Features.Payments.Queries.GetPaymentById;

public record GetPaymentByIdQuery(int Id)
    : IRequest<PaymentResponse?>;