using Microsoft.Extensions.DependencyInjection;
using TesteB3.Domain.Entitites;
using TesteB3.Domain.Repositories;
using TesteB3.Infrasctructure.Persistency;
using TesteB3.Infrasctructure.Persistency.Repositories;

namespace TesteB3.Infrasctructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddTesteB3DbContext(this IServiceCollection services)
        {
            services.AddDbContext<TesteB3DbContext>();
            services.AddTransient(typeof(IGenericRepository<>),typeof(GenericRepository<>));
            services.AddTransient(typeof(IUnitOfWork),typeof(UnitOfWork));

            return services;
        }
    }
}
