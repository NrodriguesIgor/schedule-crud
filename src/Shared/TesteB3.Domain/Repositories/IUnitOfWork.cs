using TesteB3.Domain.Entitites;

namespace TesteB3.Domain.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Schedule> Schedules { get; }
        int Complete();
        Task<int> CompleteAsync();
    }
}
