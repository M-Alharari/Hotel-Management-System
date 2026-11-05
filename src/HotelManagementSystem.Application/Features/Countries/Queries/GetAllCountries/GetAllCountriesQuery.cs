using HotelManagementSystem.Domain.Entities;
using MediatR;

namespace HotelManagementSystem.Application.Features.Countries.Queries.GetAllCountries;

public class GetAllCountriesQuery : IRequest<IEnumerable<Country>>
{
}