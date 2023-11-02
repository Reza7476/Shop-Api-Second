using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.RoleAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrustructure.Persistant.Ef.RoleAggregate
{
    internal class RoleConfiguration : IEntityTypeConfiguration<RoleAgg>
    {
        public void Configure(EntityTypeBuilder<RoleAgg> builder)
        {
            builder.ToTable("Roles", "role");
            builder.Property(b => b.Title)
                .IsRequired()
                .HasMaxLength(60);
            builder.OwnsMany(b => b.Permissions, option =>
            {
                option.ToTable("Permissions", "role");
            }); 

            
            
            
        }
    }
}
