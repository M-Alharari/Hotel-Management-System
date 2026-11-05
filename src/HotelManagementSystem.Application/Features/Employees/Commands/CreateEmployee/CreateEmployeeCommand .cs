using MediatR;

namespace HotelManagementSystem.Application.Features.Employees.Commands.CreateEmployee;

public class CreateEmployeeCommand : IRequest<int>
{
    public int PersonId { get; set; }

    public int DepartmentId { get; set; }

    public DateOnly HireDate { get; set; }

    public string JobTitle { get; set; } = null!;
}