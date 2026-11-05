using HotelManagementSystem.Application.Abstractions.Persistence;
using HotelManagementSystem.Application.Mapping;
using MediatR;

namespace HotelManagementSystem.Application.Features.Roles.Commands.CreateRole;

public class CreateRoleHandler : IRequestHandler<CreateRoleCommand, int>
{
    private readonly IRoleRepository _roleRepository;

    public CreateRoleHandler(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public async Task<int> Handle(
        CreateRoleCommand request,
        CancellationToken cancellationToken)
    {
        var existingRole = await _roleRepository.GetByNameAsync(
            request.Name.Trim());

        if (existingRole is not null)
            throw new InvalidOperationException("Role already exists.");

        var role = request.ToEntity();

        await _roleRepository.AddAsync(role);

        return role.Id;
    }
}