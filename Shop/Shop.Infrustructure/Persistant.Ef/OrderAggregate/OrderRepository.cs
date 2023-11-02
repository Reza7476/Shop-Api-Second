using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client.Extensibility;
using Shop.Domain.OrderAggregate;
using Shop.Domain.OrderAggregate.Enums;
using Shop.Domain.OrderAggregate.Repositiory;
using Shop.Infrustructure._Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrustructure.Persistant.Ef.OrderAggregate
{
    internal class OrderRepository : BaseReepository<OrderAgg>, IOrderRepositiory
    {
        public OrderRepository(ShopContext context) : base(context)
        {
        }

        public  async Task<OrderAgg?> GetCurrentUserOrder(long userId)
        {

            return await Context.orders.AsTracking().FirstOrDefaultAsync(f => f.UserId == userId
            && f.Status == OrderStatus.Pennding);
        }
    }
}
