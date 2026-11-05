using HotelManagementSystem.Application.Features.Users.Commands.CreateUser;
using HotelManagementSystem.Application.Features.Users.Models;
using HotelManagementSystem.Domain.Entities;

namespace HotelManagementSystem.Application.Mapping;

public static class UserMapping
{
    public static User ToEntity(
        this CreateUserCommand command,
        string passwordHash)
    {
        return new User
        {
            PersonId = command.PersonId,
            Username = command.Username,
            PasswordHash = passwordHash
        };
    }


    public static UserResponse ToResponse(this User user)
    {
        return new UserResponse
        {
            Id = user.Id,
            PersonId = user.PersonId,
            Username = user.Username,
            IsActive = user.IsActive,
            //CreatedAt = user.CreatedAt
        };
    }


}