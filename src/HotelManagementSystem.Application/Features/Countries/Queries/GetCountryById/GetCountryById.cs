using HotelManagementSystem.Domain.Entities;
using MediatR;

namespace HotelManagementSystem.Application.Features.Countries.Queries.GetCountryById;

public class GetCountryByIdQuery : IRequest<Country?>
{
    public int Id { get; set; }
}