using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.UserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrustructure.Persistant.Ef.UserAggregate
{
    internal class UserConfiguration : IEntityTypeConfiguration<UserAgg>
    {
        public void Configure(EntityTypeBuilder<UserAgg> builder)
        {

            builder.ToTable("Users", "user");
            builder.HasIndex(b => b.PhoneNumber).IsUnique();
            builder.HasIndex(b => b.Email).IsUnique();

            builder.Property(b => b.Email)
                .IsRequired(false)
                .HasMaxLength(256);

            builder.Property(b => b.PhoneNumber)
                .IsRequired()
                .HasMaxLength(11);

            builder.Property(b => b.Name)
                .IsRequired(false)

               .HasMaxLength(80);

            builder.Property(b => b.Family)
                .IsRequired(false)
                .HasMaxLength(80);

            builder.Property(b => b.Password)
                .IsRequired()
                .HasMaxLength(50);


            builder.OwnsMany(b => b.Addresses, option =>
            {
                option.HasIndex(b => b.UserId);
                option.ToTable("Addresses", "user");

                option.Property(b => b.Province)
                     .IsRequired().HasMaxLength(100);

                option.Property(b => b.City)
                    .IsRequired().HasMaxLength(100);

                option.Property(b => b.Name)
                   .IsRequired().HasMaxLength(50);

                option.Property(b => b.Family)
                    .IsRequired().HasMaxLength(50);


                option.Property(b => b.NationalCode)
                    .IsRequired().HasMaxLength(10);

                option.Property(b => b.PostalCode)
                    .IsRequired().HasMaxLength(20);

                option.OwnsOne(c => c.PhoneNumber, config =>
                {
                    config.Property(b => b.Value)
                        .HasColumnName("PhoneNumber")
                        .IsRequired().HasMaxLength(11);
                });
            });

            builder.OwnsMany(b => b.wallets, option =>
            {
                option.ToTable("Wallets", "user");
                option.HasIndex(b => b.UserId);

                option.Property(b => b.Description)
                    .IsRequired(false)
                    .HasMaxLength(500);
            });

            builder.OwnsMany(b => b.Roles, option =>
            {
                option.ToTable("Roles", "user");
                option.HasIndex(b => b.UserId);
            });
        }
    }
}
