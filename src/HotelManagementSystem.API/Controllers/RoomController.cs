using HotelManagementSystem.Application.Features.Rooms.Commands.CreateRoom;
using HotelManagementSystem.Application.Features.Rooms.Queries.GetAllRooms;
using HotelManagementSystem.Application.Features.Rooms.Queries.GetRoomById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagementSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RoomController : ControllerBase
{
    private readonly ISender _sender;

    public RoomController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost]
    public async Task<IActionResult> CreateRoom(CreateRoomCommand command)
    {
        var id = await _sender.Send(command);

        return CreatedAtAction(
            nameof(GetRoomById),
            new { id },
            new { id });
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetRoomById(int id)
    {
        var room = await _sender.Send(new GetRoomByIdQuery { Id = id });

        if (room is null)
            return NotFound();

        return Ok(room);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllRooms()
    {
        var rooms = await _sender.Send(new GetAllRoomsQuery());

        return Ok(rooms);
    }
}