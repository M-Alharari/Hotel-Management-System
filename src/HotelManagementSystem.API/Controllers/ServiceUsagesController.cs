using HotelManagementSystem.Application.Features.ServiceUsages.Commands.CreateServiceUsage;
using HotelManagementSystem.Application.Features.ServiceUsages.Queries.GetServiceUsageById;
using HotelManagementSystem.Application.Features.ServiceUsages.Queries.GetAllServiceUsages;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagementSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ServiceUsagesController : ControllerBase
{
    private readonly IMediator _mediator;

    public ServiceUsagesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        CreateServiceUsageCommand command)
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
            new GetServiceUsageByIdQuery(id));

        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(
            new GetAllServiceUsagesQuery());

        return Ok(result);
    }
}