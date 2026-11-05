using HotelManagementSystem.Application.Abstractions.Persistence;
using HotelManagementSystem.Domain.Entities;
using MediatR;

namespace HotelManagementSystem.Application.Features.Departments.Queries.GetAllDepartments;

public class GetAllDepartmentsHandler
    : IRequestHandler<GetAllDepartmentsQuery, IEnumerable<Department>>
{
    private readonly IDepartmentRepository _departmentRepository;

    public GetAllDepartmentsHandler(IDepartmentRepository departmentRepository)
    {
        _departmentRepository = departmentRepository;
    }

    public async Task<IEnumerable<Department>> Handle(
        GetAllDepartmentsQuery request,
        CancellationToken cancellationToken)
    {
        return await _departmentRepository.GetAllAsync();
    }
}