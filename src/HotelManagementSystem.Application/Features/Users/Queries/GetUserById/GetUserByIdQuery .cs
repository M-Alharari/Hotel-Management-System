using HotelManagementSystem.Application.Features.Users.Models;
using MediatR;

namespace HotelManagementSystem.Application.Features.Users.Queries.GetUserById;

public class GetUserByIdQuery : IRequest<UserResponse?>
{
    public int Id { get; set; }
}