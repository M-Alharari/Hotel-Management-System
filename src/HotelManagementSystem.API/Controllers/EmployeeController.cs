using HotelManagementSystem.Application.Features.Employees.Commands.CreateEmployee;
using HotelManagementSystem.Application.Features.Employees.Queries.GetAllEmployees;
using HotelManagementSystem.Application.Features.Employees.Queries.GetEmployeeById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagementSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly ISender _sender;

    public EmployeeController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost("Add-Employee")]
    public async Task<IActionResult> CreateEmployee(
        CreateEmployeeCommand command)
    {
        var id = await _sender.Send(command);

        return CreatedAtAction(
            nameof(GetEmployeeById),
            new { id },
            new { id });
    }

    [HttpGet("Get-Employee-By-Id")]
    public async Task<IActionResult> GetEmployeeById(int id)
    {
        var employee = await _sender.Send(
            new GetEmployeeByIdQuery { Id = id });

        if (employee is null)
            return NotFound();

        return Ok(employee);
    }

    [HttpGet("Get-All-Employees")]
    public async Task<IActionResult> GetAllEmployees()
    {
        var employees = await _sender.Send(
            new GetAllEmployeesQuery());

        return Ok(employees);
    }
}