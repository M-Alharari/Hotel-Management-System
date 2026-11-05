using HotelManagementSystem.Application.Features.Users.Models;
using MediatR;

namespace HotelManagementSystem.Application.Features.Users.Queries.GetAllUsers;

public class GetAllUsersQuery : IRequest<IEnumerable<UserResponse>>
{
}