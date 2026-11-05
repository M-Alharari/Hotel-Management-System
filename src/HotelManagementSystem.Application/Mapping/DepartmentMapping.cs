using HotelManagementSystem.Application.Features.Departments.Commands.CreateDepartment;
using HotelManagementSystem.Domain.Entities;

namespace HotelManagementSystem.Application.Mapping;

public static class DepartmentMapping
{
    public static Department ToEntity(this CreateDepartmentCommand command)
    {
        return new Department
        {
            Name = command.Name,
            Description = command.Description
        };
    }
}