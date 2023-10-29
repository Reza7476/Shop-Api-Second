using Common.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.OrderAggregate.Repositiory
{
    public interface IOrderRepositiory : IBaseRepository<OrderAgg>
    {
        Task<OrderAgg> GetCurrentUserOrder(long userId);

    }
}
