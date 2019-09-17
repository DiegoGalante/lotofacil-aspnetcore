using LoteriaFacil.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoteriaFacil.Domain.Interfaces
{
    public interface IPersonRepository : IRepository<Person>
    {
        Person GetByEmail(string email);
    }
}
