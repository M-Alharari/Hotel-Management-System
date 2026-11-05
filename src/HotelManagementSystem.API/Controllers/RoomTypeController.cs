using HotelManagementSystem.Application.Features.RoomTypes.Commands.CreateRoomType;
using HotelManagementSystem.Application.Features.RoomTypes.Commands.UpdateRoomType;
using HotelManagementSystem.Application.Features.RoomTypes.Commands.DeactivateRoomType;
using HotelManagementSystem.Application.Features.RoomTypes.Queries.GetRoomTypeById;
using HotelManagementSystem.Application.Features.RoomTypes.Queries.GetAllRoomTypes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagementSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RoomTypeController : ControllerBase
{
    private readonly IMediator _mediator;

    public RoomTypeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateRoomTypeCommand command)
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
            new GetRoomTypeByIdQuery { Id = id });

        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(
            new GetAllRoomTypesQuery());

        return Ok(result);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(
        int id,
        UpdateRoomTypeCommand command)
    {
        if (id != command.Id)
            return BadRequest("ID mismatch.");

        await _mediator.Send(command);

        return NoContent();
    }

    [HttpPatch("{id:int}/deactivate")]
    public async Task<IActionResult> Deactivate(int id)
    {
        await _mediator.Send(
            new DeactivateRoomTypeCommand { Id = id });

        return NoContent();
    }
}