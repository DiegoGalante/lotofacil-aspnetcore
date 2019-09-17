using LoteriaFacil.Domain.Interfaces;
using LoteriaFacil.Infra.Data.Context;

namespace LoteriaFacil.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LoteriaFacilContext _context;

        public UnitOfWork(LoteriaFacilContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
