using HotelManagementSystem.Application.Features.Roles.Commands.CreateRole;
using HotelManagementSystem.Application.Features.Roles.Queries.GetAllRoles;
using HotelManagementSystem.Application.Features.Roles.Queries.GetRoleById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagementSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RoleController : ControllerBase
{
    private readonly ISender _sender;

    public RoleController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost]
    public async Task<IActionResult> CreateRole(CreateRoleCommand command)
    {
        var id = await _sender.Send(command);

        return CreatedAtAction(
            nameof(GetRoleById),
            new { id },
            new { id });
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetRoleById(int id)
    {
        var role = await _sender.Send(new GetRoleByIdQuery { Id = id });

        if (role is null)
            return NotFound();

        return Ok(role);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllRoles()
    {
        var roles = await _sender.Send(new GetAllRolesQuery());

        return Ok(roles);
    }
}