using HotelManagementSystem.Application.Abstractions.Persistence;
using HotelManagementSystem.Domain.Entities;
using MediatR;

namespace HotelManagementSystem.Application.Features.Departments.Queries.GetDepartmentById;

public class GetDepartmentByIdHandler
    : IRequestHandler<GetDepartmentByIdQuery, Department?>
{
    private readonly IDepartmentRepository _departmentRepository;

    public GetDepartmentByIdHandler(IDepartmentRepository departmentRepository)
    {
        _departmentRepository = departmentRepository;
    }

    public async Task<Department?> Handle(
        GetDepartmentByIdQuery request,
        CancellationToken cancellationToken)
    {
        return await _departmentRepository.GetByIdAsync(request.Id);
    }
}