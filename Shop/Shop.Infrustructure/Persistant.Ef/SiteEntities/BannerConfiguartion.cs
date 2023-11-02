﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.SiteEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrustructure.Persistant.Ef.SiteEntities
{
    internal class BannerConfiguartion : IEntityTypeConfiguration<Banner>
    {
        public void Configure(EntityTypeBuilder<Banner> builder)
        {
            builder.Property(b => b.ImageName)
                  .HasMaxLength(150).IsRequired();
            
            builder.Property(b=>b.Link)
                .HasMaxLength (500).IsRequired();
        }
    }
}
