using HotelManagementSystem.Application.Abstractions.Persistence;
using HotelManagementSystem.Application.Mapping;
using HotelManagementSystem.Domain.Entities;
using MediatR;

namespace HotelManagementSystem.Application.Features.Guests.Commands.CreateGuest;

public class CreateGuestHandler
    : IRequestHandler<CreateGuestCommand, int>
{
    private readonly IGuestRepository _guestRepository;
    private readonly IPersonRepository _personRepository;
    private readonly ICountryRepository _countryRepository;

    public CreateGuestHandler(
        IGuestRepository guestRepository,
        IPersonRepository personRepository,
        ICountryRepository countryRepository)
    {
        _guestRepository = guestRepository;
        _personRepository = personRepository;
        _countryRepository = countryRepository;
    }

    public async Task<int> Handle(
        CreateGuestCommand request,
        CancellationToken cancellationToken)
    {
        var person = await _personRepository.GetByIdAsync(request.PersonId);

        if (person is null)
            throw new KeyNotFoundException("Person not found.");

         

        var guest = request.ToEntity(); 

        await _guestRepository.AddAsync(guest);

        return guest.Id;
    } 
}