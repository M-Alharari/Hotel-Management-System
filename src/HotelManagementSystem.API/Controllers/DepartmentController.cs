using HotelManagementSystem.Application.Features.Departments.Commands.CreateDepartment;
using HotelManagementSystem.Application.Features.Departments.Queries.GetAllDepartments;
using HotelManagementSystem.Application.Features.Departments.Queries.GetDepartmentById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagementSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DepartmentController : ControllerBase
{
    private readonly ISender _sender;

    public DepartmentController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost("Add-Department")]
    public async Task<IActionResult> CreateDepartment(
        CreateDepartmentCommand command)
    {
        var id = await _sender.Send(command);

        return CreatedAtAction(
            nameof(GetDepartmentById),
            new { id },
            new { id });
    }

    [HttpGet("Get-Department-By-Id")]
    public async Task<IActionResult> GetDepartmentById(int id)
    {
        var department = await _sender.Send(
            new GetDepartmentByIdQuery { Id = id });

        if (department is null)
            return NotFound();

        return Ok(department);
    }

    [HttpGet("Get-All-Departments")]
    public async Task<IActionResult> GetAllDepartments()
    {
        var departments = await _sender.Send(
            new GetAllDepartmentsQuery());

        return Ok(departments);
    }
}