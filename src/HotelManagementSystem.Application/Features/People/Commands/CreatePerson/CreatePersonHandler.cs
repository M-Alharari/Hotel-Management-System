using HotelManagementSystem.Application.Abstractions.Persistence;
using HotelManagementSystem.Application.Mapping;
using HotelManagementSystem.Domain.Entities;
using MediatR;

namespace HotelManagementSystem.Application.Features.People.Commands.CreatePerson;

public class CreatePersonHandler
    : IRequestHandler<CreatePersonCommand, int>
{
    private readonly IPersonRepository _personRepository;
    //private readonly IUnitOfWork _unitOfWork;

    public CreatePersonHandler(
        IPersonRepository personRepository/*,*/
        /*IUnitOfWork unitOfWork*/)
    {
        _personRepository = personRepository;
        //_unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(
        CreatePersonCommand request,
        CancellationToken cancellationToken)
    {
        var person = request.ToEntity();

        await _personRepository.AddAsync(person);

        

        return person.Id;
    }
}