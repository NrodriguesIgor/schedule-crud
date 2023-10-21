using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
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
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient(typeof(IUnitOfWork), typeof(UnitOfWork));

            return services;
        }

        public static IApplicationBuilder AppMigrations(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<TesteB3DbContext>();

                if (context.Database.GetPendingMigrations().Any())
                {
                    context.Database.Migrate();

                }
            }

            return app;
        }
    }
}
