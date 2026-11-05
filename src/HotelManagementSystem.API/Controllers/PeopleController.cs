using HotelManagementSystem.Application.Features.People.Commands.CreatePerson;
using HotelManagementSystem.Infrastructure.Persistence.Data;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PeopleController : ControllerBase
{
    private readonly ISender _sender;

    private readonly AppDbContext _context;

    public PeopleController(ISender sender, AppDbContext context)
    {
        _sender = sender;
        _context = context;
    }


    [HttpGet]
    public async Task<IActionResult> GetAllPeople()
    {
        var people = await _context.People.ToListAsync();

        return Ok(people);
    }


    [HttpPost]
    public async Task<IActionResult> CreatePerson(
        CreatePersonCommand command)
    {
        var personId = await _sender.Send(command);

        return CreatedAtAction(
            nameof(CreatePerson),
            new { id = personId },
            new { id = personId });
    }
}