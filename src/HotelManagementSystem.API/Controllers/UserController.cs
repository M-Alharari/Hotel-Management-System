using HotelManagementSystem.Application.Features.Users.Commands.CreateUser;
using HotelManagementSystem.Application.Features.Users.Models;
using HotelManagementSystem.Application.Features.Users.Queries.GetAllUsers;
using HotelManagementSystem.Application.Features.Users.Queries.GetUserById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagementSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly ISender _sender;

    public UserController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser(CreateUserCommand command)
    {
        var user = await _sender.Send(command);

        return CreatedAtAction(
            nameof(GetUserById),
            new { id = user.Id },
            user);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetUserById(int id)
    {
        var user = await _sender.Send(new GetUserByIdQuery { Id = id });

        if (user is null)
            return NotFound();

        return Ok(user);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await _sender.Send(new GetAllUsersQuery());

        return Ok(users);
    }
}