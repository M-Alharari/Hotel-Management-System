using HotelManagementSystem.Application.Features.HotelServices.Commands.CreateHotelService;
using HotelManagementSystem.Application.Features.HotelServices.Commands.UpdateHotelService;
using HotelManagementSystem.Application.Features.HotelServices.Commands.DeactivateHotelService;
using HotelManagementSystem.Application.Features.HotelServices.Queries.GetHotelServiceById;
using HotelManagementSystem.Application.Features.HotelServices.Queries.GetAllHotelServices;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagementSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HotelServicesController : ControllerBase
{
    private readonly IMediator _mediator;

    public HotelServicesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        CreateHotelServiceCommand command)
    {
        var id = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id }, new { id });
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _mediator.Send(
            new GetHotelServiceByIdQuery(id));

        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(
            new GetAllHotelServicesQuery());

        return Ok(result);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(
        int id,
        UpdateHotelServiceCommand command)
    {
        command.Id = id;

        await _mediator.Send(command);

        return NoContent();
    }

    [HttpPatch("{id:int}/deactivate")]
    public async Task<IActionResult> Deactivate(int id)
    {
        await _mediator.Send(
            new DeactivateHotelServiceCommand(id));

        return NoContent();
    }
}