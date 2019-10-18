using LoteriaFacil.Domain.Models;
using System;
using System.Text;

namespace LoteriaFacil.Domain.Interfaces
{
    public interface IPersonRepository : IRepository<Person>
    {
        Person GetByEmail(string email);
    }
}
