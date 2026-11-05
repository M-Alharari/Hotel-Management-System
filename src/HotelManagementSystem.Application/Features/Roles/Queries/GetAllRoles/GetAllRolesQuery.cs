using HotelManagementSystem.Domain.Entities;
using MediatR;

namespace HotelManagementSystem.Application.Features.Roles.Queries.GetAllRoles;

public class GetAllRolesQuery : IRequest<IEnumerable<Role>>
{
}