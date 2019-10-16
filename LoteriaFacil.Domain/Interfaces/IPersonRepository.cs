using LoteriaFacil.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LoteriaFacil.Domain.Interfaces
{
    public interface IPersonRepository : IRepository<Person>
    {
        Person GetByEmail(string email);
        Task<IEnumerable<Person>> GetByDemand(int start = 0, int end = 0);
    }
}
