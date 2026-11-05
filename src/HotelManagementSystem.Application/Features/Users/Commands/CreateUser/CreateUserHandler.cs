using HotelManagementSystem.Application.Abstractions.Persistence;
using HotelManagementSystem.Application.Abstractions.Services;
using HotelManagementSystem.Application.Features.Users.Models;
using HotelManagementSystem.Application.Mapping;
using MediatR;

namespace HotelManagementSystem.Application.Features.Users.Commands.CreateUser;

public class CreateUserHandler : IRequestHandler<CreateUserCommand, UserResponse>
{
    private readonly IUserRepository _userRepository;
    private readonly IPersonRepository _personRepository;
    private readonly IPasswordHasherService _passwordHasher;

    public CreateUserHandler(
        IUserRepository userRepository,
        IPersonRepository personRepository,
        IPasswordHasherService passwordHasher)
    {
        _userRepository = userRepository;
        _personRepository = personRepository;
        _passwordHasher = passwordHasher;
    }

    public async Task<UserResponse> Handle(
        CreateUserCommand request,
        CancellationToken cancellationToken)
    {
        var person = await _personRepository.GetByIdAsync(request.PersonId);

        if (person is null)
            throw new KeyNotFoundException("Person not found.");

        var existingUser = await _userRepository
            .GetByUsernameAsync(request.Username);

        if (existingUser is not null)
            throw new InvalidOperationException("Username already exists.");

        var passwordHash = _passwordHasher.HashPassword(request.Password);

        var user = request.ToEntity(passwordHash);

        await _userRepository.AddAsync(user);

        return user.ToResponse();
    }
}