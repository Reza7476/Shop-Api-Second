using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.SellerAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrustructure.Persistant.Ef.SellerAggregate
{
    internal class SellerConfiguration : IEntityTypeConfiguration<SellerAgg>
    {
        public void Configure(EntityTypeBuilder<SellerAgg> builder)
        {
            builder.ToTable("Sellers", "seller");
            builder.HasIndex(b => b.NatiaonalCode).IsUnique();

            builder.Property(b => b.NatiaonalCode)
                .IsRequired();
            builder.Property (b => b.ShopName)
                .IsRequired();
            builder.OwnsMany(b => b.Inventories, option =>
            {
                option.ToTable("Inventories", "seller");
                option.HasKey(b => b.Id);
                option.HasIndex(b => b.ProductId);
                option.HasIndex(b => b.SellerId);
            });
            
            
            
        }
    }
}
