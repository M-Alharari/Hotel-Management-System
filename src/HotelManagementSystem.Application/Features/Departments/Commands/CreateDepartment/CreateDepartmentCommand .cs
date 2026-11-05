using MediatR;

namespace HotelManagementSystem.Application.Features.Departments.Commands.CreateDepartment;

public class CreateDepartmentCommand : IRequest<int>
{
    public string Name { get; set; } = null!;

    public string? Description { get; set; }
}