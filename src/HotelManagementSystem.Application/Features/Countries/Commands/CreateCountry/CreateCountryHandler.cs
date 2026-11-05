using HotelManagementSystem.Application.Abstractions.Persistence;
using HotelManagementSystem.Application.Mapping;
using MediatR;

namespace HotelManagementSystem.Application.Features.Countries.Commands.CreateCountry;

public class CreateCountryHandler : IRequestHandler<CreateCountryCommand, int>
{
    private readonly ICountryRepository _countryRepository;

    public CreateCountryHandler(ICountryRepository countryRepository)
    {
        _countryRepository = countryRepository;
    }

    public async Task<int> Handle(
        CreateCountryCommand request,
        CancellationToken cancellationToken)
    {
        var country = request.ToEntity();

        await _countryRepository.AddAsync(country);

        return country.Id;
    }
}