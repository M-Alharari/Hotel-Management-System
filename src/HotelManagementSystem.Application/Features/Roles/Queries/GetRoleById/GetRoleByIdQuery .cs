using HotelManagementSystem.Domain.Entities;
using MediatR;

namespace HotelManagementSystem.Application.Features.Roles.Queries.GetRoleById;

public class GetRoleByIdQuery : IRequest<Role?>
{
    public int Id { get; set; }
}