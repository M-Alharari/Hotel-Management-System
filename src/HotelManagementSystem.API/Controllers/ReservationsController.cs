using HotelManagementSystem.Application.Features.Reservations.Commands.CreateReservation;
using HotelManagementSystem.Application.Features.Reservations.Commands.ChangeReservationStatus;
using HotelManagementSystem.Application.Features.Reservations.Queries.GetReservationById;
using HotelManagementSystem.Application.Features.Reservations.Queries.GetAllReservations;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagementSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReservationsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ReservationsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        [FromBody] CreateReservationCommand command)
    {
        var id = await _mediator.Send(command);

        return CreatedAtAction(
            nameof(GetById),
            new { id },
            new { id });
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _mediator.Send(
            new GetReservationByIdQuery { Id = id });

        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(
            new GetAllReservationsQuery());

        return Ok(result);
    }

    [HttpPatch("{id:int}/status")]
    public async Task<IActionResult> ChangeStatus(
        int id,
        [FromBody] ChangeReservationStatusCommand command)
    {
        command.Id = id;

        await _mediator.Send(command);

        return NoContent();
    }
}