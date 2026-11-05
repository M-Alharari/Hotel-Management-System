using HotelManagementSystem.Application.Abstractions.Persistence;
using HotelManagementSystem.Domain.Entities;
using MediatR;

namespace HotelManagementSystem.Application.Features.Employees.Queries.GetAllEmployees;

public class GetAllEmployeesHandler
    : IRequestHandler<GetAllEmployeesQuery, IEnumerable<Employee>>
{
    private readonly IEmployeeRepository _employeeRepository;

    public GetAllEmployeesHandler(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<IEnumerable<Employee>> Handle(
        GetAllEmployeesQuery request,
        CancellationToken cancellationToken)
    {
        return await _employeeRepository.GetAllAsync();
    }
}