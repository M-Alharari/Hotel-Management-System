using HotelManagementSystem.Domain.Entities;
using MediatR;

namespace HotelManagementSystem.Application.Features.Departments.Queries.GetDepartmentById;

public class GetDepartmentByIdQuery : IRequest<Department?>
{
    public int Id { get; set; }
}