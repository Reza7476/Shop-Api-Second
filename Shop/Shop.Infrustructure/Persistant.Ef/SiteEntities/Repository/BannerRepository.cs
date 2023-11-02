using Common.Domain.Repository;
using Microsoft.EntityFrameworkCore.Metadata;
using Shop.Domain.SiteEntities;
using Shop.Domain.SiteEntities.Repositories;
using Shop.Infrustructure._Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrustructure.Persistant.Ef.SiteEntities.Repository
{
    internal class BannerRepository : BaseReepository<Banner>,IBannerRepository
    {
        public BannerRepository(ShopContext context) : base(context)
        {
        }

        public void Delete(Banner banner)
        {
            Context.banners.Remove(banner);
        }

       
    }
}
