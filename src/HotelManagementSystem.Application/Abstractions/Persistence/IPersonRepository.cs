using HotelManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagementSystem.Application.Abstractions.Persistence
{
    public interface IPersonRepository
    {
        Task<Person?> GetByIdAsync(int id);

        Task AddAsync(Person person);

        void Update(Person person);

        void Delete(Person person);
    }
}
