using HotelManagementSystem.Application.Features.Payments.Commands.ChangePaymentStatus;
using HotelManagementSystem.Application.Features.Payments.Commands.CreatePayment;
using HotelManagementSystem.Application.Features.Payments.Queries.GetAllPayments;
using HotelManagementSystem.Application.Features.Payments.Queries.GetPaymentById;
using HotelManagementSystem.Application.Features.Payments.Queries.GetPaymentsByReservation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagementSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PaymentsController : ControllerBase
{
    private readonly IMediator _mediator;

    public PaymentsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreatePaymentCommand command)
    {
        var id = await _mediator.Send(command);

        return CreatedAtAction(
            nameof(GetById),
            new { id },
            new { id });
    }

    [HttpPatch("{id:int}/status")]
    public async Task<IActionResult> ChangeStatus(
        int id,
        [FromBody] ChangePaymentStatusRequest request)
    {
        var result = await _mediator.Send(
            new ChangePaymentStatusCommand(id, request.Status));

        return result ? NoContent() : NotFound();
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var payment = await _mediator.Send(
            new GetPaymentByIdQuery(id));

        return payment is null ? NotFound() : Ok(payment);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var payments = await _mediator.Send(
            new GetAllPaymentsQuery());

        return Ok(payments);
    }

    [HttpGet("reservation/{reservationId:int}")]
    public async Task<IActionResult> GetByReservation(int reservationId)
    {
        var payments = await _mediator.Send(
            new GetPaymentsByReservationQuery(reservationId));

        return Ok(payments);
    }
}