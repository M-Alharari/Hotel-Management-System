namespace HotelManagementSystem.Application.Features.Users.Models;

public class UserResponse
{
    public int Id { get; set; }
    public int PersonId { get; set; }
    public string Username { get; set; } = null!;
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
}