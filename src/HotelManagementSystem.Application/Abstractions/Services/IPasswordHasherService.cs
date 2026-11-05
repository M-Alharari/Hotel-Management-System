namespace HotelManagementSystem.Application.Abstractions.Services;

public interface IPasswordHasherService
{
    string HashPassword(string password);
}