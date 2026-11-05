using HotelManagementSystem.Application.Features.Employees.Commands.CreateEmployee;
using HotelManagementSystem.Domain.Entities;

namespace HotelManagementSystem.Application.Mapping;

public static class EmployeeMapping
{
    public static Employee ToEntity(this CreateEmployeeCommand command)
    {
        return new Employee
        {
            PersonId = command.PersonId,
            DepartmentId = command.DepartmentId,
            HireDate = command.HireDate,
            JobTitle = command.JobTitle
        };
    }
}