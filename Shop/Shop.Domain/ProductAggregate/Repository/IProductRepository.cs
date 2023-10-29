using Common.Domain.Repository;
using Shop.Domain.ProductAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.ProductAggregate.Repository
{
    public interface IProductRepository : IBaseRepository<ProductAgg>
    {
    }
}
