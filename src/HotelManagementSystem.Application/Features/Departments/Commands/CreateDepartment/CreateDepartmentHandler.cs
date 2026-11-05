using HotelManagementSystem.Application.Abstractions.Persistence;
using HotelManagementSystem.Application.Mapping;
using MediatR;

namespace HotelManagementSystem.Application.Features.Departments.Commands.CreateDepartment;

public class CreateDepartmentHandler
    : IRequestHandler<CreateDepartmentCommand, int>
{
    private readonly IDepartmentRepository _departmentRepository;

    public CreateDepartmentHandler(IDepartmentRepository departmentRepository)
    {
        _departmentRepository = departmentRepository;
    }

    public async Task<int> Handle(
        CreateDepartmentCommand request,
        CancellationToken cancellationToken)
    {
        var department = request.ToEntity();

        await _departmentRepository.AddAsync(department);

        return department.Id;
    }
}