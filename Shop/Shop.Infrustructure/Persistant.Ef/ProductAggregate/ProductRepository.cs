using Shop.Domain.ProductAggregate;
using Shop.Domain.ProductAggregate.Repository;
using Shop.Infrustructure._Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrustructure.Persistant.Ef.ProductAggregate
{
    public class ProductRepository : BaseReepository<ProductAgg>, IProductRepository
    {
        public ProductRepository(ShopContext context) : base(context)
        {
        }
    }
}
