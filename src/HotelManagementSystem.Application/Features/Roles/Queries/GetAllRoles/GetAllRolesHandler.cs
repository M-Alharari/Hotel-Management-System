using HotelManagementSystem.Application.Abstractions.Persistence;
using HotelManagementSystem.Domain.Entities;
using MediatR;

namespace HotelManagementSystem.Application.Features.Roles.Queries.GetAllRoles;

public class GetAllRolesHandler : IRequestHandler<GetAllRolesQuery, IEnumerable<Role>>
{
    private readonly IRoleRepository _roleRepository;

    public GetAllRolesHandler(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public async Task<IEnumerable<Role>> Handle(
        GetAllRolesQuery request,
        CancellationToken cancellationToken)
    {
        return await _roleRepository.GetAllAsync();
    }
}