using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TesteB3.Domain.Entitites;

namespace TesteB3.Infrasctructure.Persistency.Mappings
{
    public class ScheduleMap : IEntityTypeConfiguration<Schedule>
    {
        public void Configure(EntityTypeBuilder<Schedule> builder)
        {
           

            builder.ToTable("schedules");

            builder
                .Property(x => x.Date)
                    .HasColumnName("date")
                    .IsRequired();

            builder
                .Property(x => x.Done)
                    .HasColumnName("done")
                    .IsRequired();


            builder
                .Property(x => x.Description)
                    .HasColumnName("description")
                    .IsRequired();
        }
    }
}
