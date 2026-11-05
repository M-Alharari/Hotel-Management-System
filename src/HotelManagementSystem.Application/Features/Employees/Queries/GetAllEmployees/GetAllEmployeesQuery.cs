using HotelManagementSystem.Domain.Entities;
using MediatR;

namespace HotelManagementSystem.Application.Features.Employees.Queries.GetAllEmployees;

public class GetAllEmployeesQuery : IRequest<IEnumerable<Employee>>
{
}