using FluentValidation;

namespace HotelManagementSystem.Application.Features.Invoices.Commands.CreateInvoice;

public class CreateInvoiceValidator : AbstractValidator<CreateInvoiceCommand>
{
    public CreateInvoiceValidator()
    {
        RuleFor(x => x.ReservationId)
            .GreaterThan(0);
    }
}