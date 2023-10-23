using Microsoft.EntityFrameworkCore;
using TesteB3.Domain.Entitites;

namespace TesteB3.Infrasctructure.Persistency
{
    public class TesteB3DbContext : DbContext
    {

        public DbSet<Schedule> Todos { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseNpgsql(Environment.GetEnvironmentVariable("POSTGRES_CONNECTIONSTRING"));
        //protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseNpgsql("User ID=postgres;Password=mysecretpassword;Host=localhost;Port=5432;Database=postgres;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TesteB3DbContext).Assembly);
        }

    }
}
