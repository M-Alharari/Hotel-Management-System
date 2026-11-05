using HotelManagementSystem.Application.Abstractions.Persistence;
using HotelManagementSystem.Domain.Entities;
using MediatR;

namespace HotelManagementSystem.Application.Features.Countries.Queries.GetCountryById;

public class GetCountryByIdHandler
    : IRequestHandler<GetCountryByIdQuery, Country?>
{
    private readonly ICountryRepository _countryRepository;

    public GetCountryByIdHandler(ICountryRepository countryRepository)
    {
        _countryRepository = countryRepository;
    }

    public async Task<Country?> Handle(
        GetCountryByIdQuery request,
        CancellationToken cancellationToken)
    {
        return await _countryRepository.GetByIdAsync(request.Id);
    }
}