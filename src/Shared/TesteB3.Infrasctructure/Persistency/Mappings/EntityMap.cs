using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteB3.Domain.Entitites;
using TesteB3.Domain.Shared.Entitites;

namespace TesteB3.Infrasctructure.Persistency.Mappings
{
    public class EntityMap : IEntityTypeConfiguration<Entity>
    {



        public void Configure(EntityTypeBuilder<Entity> builder)
        {
            builder.UseTpcMappingStrategy();
            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder
                .Property(x => x.CreatedAt)
                    .HasColumnName("created_at")
                    .IsRequired();

            builder
                .Property(x => x.UpdatedAt)
                    .HasColumnName("updated_at");

        }
    }

    
}
