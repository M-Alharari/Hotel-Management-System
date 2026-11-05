using HotelManagementSystem.Application.Abstractions.Persistence;
using HotelManagementSystem.Domain.Entities;
using MediatR;

namespace HotelManagementSystem.Application.Features.Employees.Queries.GetEmployeeById;

public class GetEmployeeByIdHandler
    : IRequestHandler<GetEmployeeByIdQuery, Employee?>
{
    private readonly IEmployeeRepository _employeeRepository;

    public GetEmployeeByIdHandler(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<Employee?> Handle(
        GetEmployeeByIdQuery request,
        CancellationToken cancellationToken)
    {
        return await _employeeRepository.GetByIdAsync(request.Id);
    }
}