using Microsoft.EntityFrameworkCore;
using Shop.Domain.CategoryAggreagate;
using Shop.Domain.CommentAggregate;
using Shop.Domain.OrderAggregate;
using Shop.Domain.ProductAggregate;
using Shop.Domain.RoleAggregate;
using Shop.Domain.SellerAggregate;
using Shop.Domain.SiteEntities;
using Shop.Domain.UserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrustructure.Persistant.Ef
{
    public class ShopContext:DbContext
    {


        public ShopContext(DbContextOptions<ShopContext> options):base(options)
        {
            
        }

        // intruduce dbsets they are just aggregates 

        public DbSet<CategoryAgg> categories { get; set; }
        public DbSet<CommentAgg> comments { get; set; }
        public DbSet<OrderAgg> orders { get; set; }
        public DbSet<RoleAgg> roles { get; set; }
        public DbSet<ProductAgg> products { get; set; }
        public DbSet<SellerAgg> sellers { get; set; }
        public DbSet<Slider> sliders { get; set; }
        public DbSet<Banner> banners { get; set; }
        public DbSet<UserAgg> users { get; set; }

        //فقط برای مشاهده خطا

        public DbSet<SellerInventoryAgg> inventories { get; set; }

        //
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ShopContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

    }
}
 