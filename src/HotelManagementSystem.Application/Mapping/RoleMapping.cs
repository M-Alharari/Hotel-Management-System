using HotelManagementSystem.Application.Features.Roles.Commands.CreateRole;
using HotelManagementSystem.Domain.Entities;

namespace HotelManagementSystem.Application.Mapping;

public static class RoleMapping
{
    public static Role ToEntity(this CreateRoleCommand command)
    {
        return new Role
        {
            Name = command.Name.Trim(),
            Description = command.Description?.Trim()
        };
    }
}