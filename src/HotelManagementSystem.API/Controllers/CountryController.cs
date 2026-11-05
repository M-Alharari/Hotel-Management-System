using HotelManagementSystem.Application.Features.Countries.Commands.CreateCountry;
using HotelManagementSystem.Application.Features.Countries.Queries.GetAllCountries;
using HotelManagementSystem.Application.Features.Countries.Queries.GetCountryById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagementSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CountryController : ControllerBase
{
    private readonly ISender _sender;

    public CountryController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost("Add-Country")]
    public async Task<IActionResult> CreateCountry(
        CreateCountryCommand command)
    {
        var id = await _sender.Send(command);

        return CreatedAtAction(
            nameof(GetCountryById),
            new { id },
            new { id });
    }

    [HttpGet("Get-Country-By-Id")]
    public async Task<IActionResult> GetCountryById(int id)
    {
        var country = await _sender.Send(
            new GetCountryByIdQuery { Id = id });

        if (country is null)
            return NotFound();

        return Ok(country);
    }

    [HttpGet("Get-All-Countries")]
    public async Task<IActionResult> GetAllCountries()
    {
        var countries = await _sender.Send(
            new GetAllCountriesQuery());

        return Ok(countries);
    }
}