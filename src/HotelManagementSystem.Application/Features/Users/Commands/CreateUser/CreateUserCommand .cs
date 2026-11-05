using HotelManagementSystem.Application.Features.Users.Models;
using MediatR;

namespace HotelManagementSystem.Application.Features.Users.Commands.CreateUser;

public class CreateUserCommand : IRequest<UserResponse>
{
    public int PersonId { get; set; }
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
}