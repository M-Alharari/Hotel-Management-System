using HotelManagementSystem.Application.Abstractions.Persistence;
using HotelManagementSystem.Domain.Entities;
using MediatR;

namespace HotelManagementSystem.Application.Features.Countries.Queries.GetAllCountries;

public class GetAllCountriesHandler
    : IRequestHandler<GetAllCountriesQuery, IEnumerable<Country>>
{
    private readonly ICountryRepository _countryRepository;

    public GetAllCountriesHandler(ICountryRepository countryRepository)
    {
        _countryRepository = countryRepository;
    }

    public async Task<IEnumerable<Country>> Handle(
        GetAllCountriesQuery request,
        CancellationToken cancellationToken)
    {
        return await _countryRepository.GetAllAsync();
    }
}