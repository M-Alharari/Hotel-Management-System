using HotelManagementSystem.Application.Features.Guests.Commands.CreateGuest;
using HotelManagementSystem.Application.Features.Guests.Queries.GetAllGuests;
using HotelManagementSystem.Application.Features.Guests.Queries.GetGuestById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagementSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GuestController : ControllerBase
{
    private readonly ISender _sender;

    public GuestController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost("Add-Guest")]
    public async Task<IActionResult> CreateGuest(CreateGuestCommand command)
    {
        var id = await _sender.Send(command);

        return CreatedAtAction(
            nameof(GetGuestById),
            new { id },
            new { id });
    }

    [HttpGet("Get-Guest-By-Id")]
    public async Task<IActionResult> GetGuestById(int id)
    {
        var guest = await _sender.Send(new GetGuestByIdQuery { Id = id });

        if (guest is null)
            return NotFound();

        return Ok(guest);
    }

    [HttpGet("Get-All-Guests")]
    public async Task<IActionResult> GetAllGuests()
    {
        var guests = await _sender.Send(new GetAllGuestsQuery());

        return Ok(guests);
    }
}