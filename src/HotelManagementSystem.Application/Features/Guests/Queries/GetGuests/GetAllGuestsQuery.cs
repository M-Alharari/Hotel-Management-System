using HotelManagementSystem.Domain.Entities;
using MediatR;

namespace HotelManagementSystem.Application.Features.Guests.Queries.GetAllGuests;

public class GetAllGuestsQuery : IRequest<IEnumerable<Guest>>
{
}