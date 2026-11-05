using HotelManagementSystem.Domain.Entities;
using MediatR;

namespace HotelManagementSystem.Application.Features.Employees.Queries.GetEmployeeById;

public class GetEmployeeByIdQuery : IRequest<Employee?>
{
    public int Id { get; set; }
}