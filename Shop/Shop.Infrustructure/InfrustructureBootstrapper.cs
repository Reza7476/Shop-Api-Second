using Microsoft.Extensions.DependencyInjection;
using Shop.Domain.CategoryAggreagate;
using Shop.Domain.CommentAggregate;
using Shop.Domain.OrderAggregate.Repositiory;
using Shop.Domain.ProductAggregate.Repository;
using Shop.Domain.RoleAggregate.Repository;
using Shop.Domain.SellerAggregate.Repository;
using Shop.Domain.SiteEntities.Repositories;
using Shop.Domain.UserAggregate.Repository;
using Shop.Infrustructure.Persistant.Ef.CategoryAggregate;
using Shop.Infrustructure.Persistant.Ef.CommentAggregate;
using Shop.Infrustructure.Persistant.Ef.OrderAggregate;
using Shop.Infrustructure.Persistant.Ef.ProductAggregate;
using Shop.Infrustructure.Persistant.Ef.RoleAggregate;
using Shop.Infrustructure.Persistant.Ef.SellerAggregate;
using Shop.Infrustructure.Persistant.Ef.SiteEntities.Repository;
using Shop.Infrustructure.Persistant.Ef.UserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrustructure
{
    public static class InfrustructureBootstrapper
    {
        public static void Init (this IServiceCollection service)
        {
           service.AddTransient<ICategoryRepository, CategoryRepository>();
           service.AddTransient<IOrderRepositiory, OrderRepository>();
           service.AddTransient<IProductRepository, ProductRepository>();
           service.AddTransient<IRoleRepository, RoleRepository>();
           service.AddTransient<IBannerRepository, BannerRepository>();
           service.AddTransient<ISliderRepository, SliderRepository>();
           service.AddTransient<IUserRepository, UserRepository>();
           service.AddTransient<ICommentRepositoey, CommentRepository>();
           service.AddTransient<ISellerRepository,SellerRepository>();
        
        
        }
    }
}
