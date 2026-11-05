using HotelManagementSystem.Application.Features.Invoices.Commands.CreateInvoice;
using HotelManagementSystem.Application.Features.Invoices.Commands.VoidInvoice;
using HotelManagementSystem.Application.Features.Invoices.Queries.GetAllInvoices;
using HotelManagementSystem.Application.Features.Invoices.Queries.GetInvoiceById;
using HotelManagementSystem.Application.Features.Invoices.Queries.GetInvoicesByReservation;
using HotelManagementSystem.Application.Features.Payments.Commands.AllocatePayment;
using HotelManagementSystem.Application.Features.Payments.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagementSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InvoicesController : ControllerBase
{
    private readonly IMediator _mediator;

    public InvoicesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("reservation/{reservationId:int}")]
    public async Task<IActionResult> Create(int reservationId)
    {
        var id = await _mediator.Send(
            new CreateInvoiceCommand(reservationId));

        return CreatedAtAction(
            nameof(GetById),
            new { id },
            new { id });
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var invoice = await _mediator.Send(
            new GetInvoiceByIdQuery(id));

        return invoice is null ? NotFound() : Ok(invoice);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var invoices = await _mediator.Send(
            new GetAllInvoicesQuery());

        return Ok(invoices);
    }

    [HttpGet("reservation/{reservationId:int}")]
    public async Task<IActionResult> GetByReservation(int reservationId)
    {
        var invoices = await _mediator.Send(
            new GetInvoicesByReservationQuery(reservationId));

        return Ok(invoices);
    }

    [HttpPatch("{id:int}/void")]
    public async Task<IActionResult> Void(int id)
    {
        await _mediator.Send(new VoidInvoiceCommand(id));

        return NoContent();
    }

    [HttpPost("{paymentId:int}/allocations")]
    public async Task<IActionResult> Allocate(
    int paymentId,
    [FromBody] AllocatePaymentRequest request)
    {
        var id = await _mediator.Send(
            new AllocatePaymentCommand(
                paymentId,
                request.InvoiceId,
                request.Amount));

        return Ok(new { id });
    }
}