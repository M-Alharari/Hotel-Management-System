namespace HotelManagementSystem.Application.Features.Payments.Requests;

public record AllocatePaymentRequest(
    int InvoiceId,
    decimal Amount);