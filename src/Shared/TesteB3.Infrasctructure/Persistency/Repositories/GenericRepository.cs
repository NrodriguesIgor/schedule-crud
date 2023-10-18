using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TesteB3.Domain.Repositories;
using TesteB3.Domain.Shared.Entitites;

namespace TesteB3.Infrasctructure.Persistency.Repositories
{

    public class GenericRepository<T> : IGenericRepository<T> where T : Entity
    {
        protected readonly TesteB3DbContext _context;

        public GenericRepository(TesteB3DbContext context)
        {
            _context = context;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate, bool asNoTracking = false)
        {
            if (asNoTracking)
                return await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(predicate);

            return await _context.Set<T>().FirstOrDefaultAsync(predicate);
        }


        public async Task<IQueryable<T>> ListAsync(Expression<Func<T, bool>> predicate, bool asNoTracking = false)
        {
            if (asNoTracking)
                return  _context.Set<T>().AsNoTracking().Where(predicate);

            return _context.Set<T>().Where(predicate);
        }


        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        

    }
}


