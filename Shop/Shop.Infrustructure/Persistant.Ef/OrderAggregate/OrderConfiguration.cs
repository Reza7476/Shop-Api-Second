using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.OrderAggregate;
using Shop.Domain.OrderAggregate.Repositiory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrustructure.Persistant.Ef.OrderAggregate
{
    internal class OrderConfiguration : IEntityTypeConfiguration<OrderAgg>
    {
        public void Configure(EntityTypeBuilder<OrderAgg> builder)
        {

            builder.ToTable("orders", "order");
            builder.OwnsOne(b => b.Discount, option =>
            {
                option.Property(b => b.DiscountTitle)
                .HasMaxLength(50);
            });
            builder.OwnsOne(b => b.ShippingMethod, option =>
            {
                option.Property(b => b.ShippingType)
                .HasMaxLength(50);
            });

            // interducing old child
            builder.OwnsMany(b => b.Items, option =>
            {
                option.ToTable("Items", "order");
            });
            builder.OwnsOne(b => b.Address, option =>
            {
                option.ToTable("Addresses", "order");
                option.HasKey(b => b.Id);

                option.Property(b => b.City)
                  .HasMaxLength(50);

                option.Property(b => b.PhoneNumber)
                  .HasMaxLength(11);

                option.Property(b => b.Family)
                  .HasMaxLength(100);

                option.Property(b => b.Name)
                  .HasMaxLength(100);

                option.Property(b => b.NationalCode)
                  .HasMaxLength(10);


                option.Property(b => b.PostalCode)
                   .HasMaxLength(40);


            });
        }


    }
}
