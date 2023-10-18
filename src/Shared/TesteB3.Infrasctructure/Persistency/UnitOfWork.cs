using TesteB3.Domain.Entitites;
using TesteB3.Domain.Repositories;

namespace TesteB3.Infrasctructure.Persistency
{
    public class UnitOfWork : IUnitOfWork
    { 
        private readonly TesteB3DbContext _context; 

        public UnitOfWork(TesteB3DbContext context, IGenericRepository<Schedule> schedules)
        {
            _context = context;
            Schedules = schedules;
        }

        public IGenericRepository<Schedule> Schedules { get; set; }


        public int Complete()
        {
            return _context.SaveChanges();
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}

