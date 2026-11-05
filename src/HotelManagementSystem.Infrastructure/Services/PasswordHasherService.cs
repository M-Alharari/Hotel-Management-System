using HotelManagementSystem.Application.Abstractions.Services;
using Microsoft.AspNetCore.Identity;

namespace HotelManagementSystem.Infrastructure.Services;

public class PasswordHasherService : IPasswordHasherService
{
    private readonly PasswordHasher<object> _hasher = new();
    private readonly object _userContext = new();

    public string HashPassword(string password)
    {
        return _hasher.HashPassword(_userContext, password);
    }
}