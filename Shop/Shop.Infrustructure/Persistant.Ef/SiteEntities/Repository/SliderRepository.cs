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
    internal class SliderRepository : BaseReepository<Slider>, ISliderRepository
    {
        public SliderRepository(ShopContext context) : base(context)
        {
        }

        public void Delete(Slider slider)
        {
           Context.sliders.Remove(slider);
        }
    }
}
