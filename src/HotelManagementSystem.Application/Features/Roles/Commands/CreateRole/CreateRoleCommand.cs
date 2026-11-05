using MediatR;

namespace HotelManagementSystem.Application.Features.Roles.Commands.CreateRole;

public class CreateRoleCommand : IRequest<int>
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
}