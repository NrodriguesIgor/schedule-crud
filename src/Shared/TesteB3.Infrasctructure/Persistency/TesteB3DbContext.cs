using Microsoft.EntityFrameworkCore;
using TesteB3.Domain.Entitites;

namespace TesteB3.Infrasctructure.Persistency
{
    public class TesteB3DbContext : DbContext
    {

        public DbSet<Schedule> Todos { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite("DataSource=app.db;Cache=Shared");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TesteB3DbContext).Assembly);
        }

    }
}
