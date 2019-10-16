using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoteriaFacil.Domain.Interfaces;
using LoteriaFacil.Domain.Models;
using LoteriaFacil.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace LoteriaFacil.Infra.Data.Repository
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        public PersonRepository(LoteriaFacilContext context) : base(context)
        {

        }

        public Person GetByEmail(string email)
        {
            return DbSet.AsNoTracking().FirstOrDefault(c => c.Email == email);
        }


        public async Task<IEnumerable<Person>> GetByDemand(int start = 0, int end = 0)
        {
            var padrao = 5000;
            return await Task.Run(() => DbSet.AsNoTracking().Take(padrao));
        }
    }
}
