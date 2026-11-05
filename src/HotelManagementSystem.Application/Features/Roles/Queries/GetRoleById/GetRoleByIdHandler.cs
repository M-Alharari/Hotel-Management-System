using HotelManagementSystem.Application.Abstractions.Persistence;
using HotelManagementSystem.Domain.Entities;
using MediatR;

namespace HotelManagementSystem.Application.Features.Roles.Queries.GetRoleById;

public class GetRoleByIdHandler : IRequestHandler<GetRoleByIdQuery, Role?>
{
    private readonly IRoleRepository _roleRepository;

    public GetRoleByIdHandler(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public async Task<Role?> Handle(
        GetRoleByIdQuery request,
        CancellationToken cancellationToken)
    {
        return await _roleRepository.GetByIdAsync(request.Id);
    }
}