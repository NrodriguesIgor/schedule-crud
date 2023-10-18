using System.Linq.Expressions;
using TesteB3.Domain.Shared.Entitites;

namespace TesteB3.Domain.Repositories
{
    public interface IGenericRepository<T> where T : Entity
    {
        Task AddAsync(T entity);
        void Delete(T entity);
        Task<T> GetAsync(Expression<Func<T, bool>> predicate, bool asNoTracking = false);
        Task<T> GetByIdAsync(int id);
        Task<IQueryable<T>> ListAsync(Expression<Func<T, bool>> predicate, bool asNoTracking = false);
        void Update(T entity);
    }
}