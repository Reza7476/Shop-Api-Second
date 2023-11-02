using Microsoft.EntityFrameworkCore;
using Shop.Domain.SellerAggregate;
using Shop.Domain.SellerAggregate.Repository;
using Shop.Infrustructure._Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrustructure.Persistant.Ef.SellerAggregate
{
    internal class SellerRepository : BaseReepository<SellerAgg>, ISellerRepository
    {
        public SellerRepository(ShopContext context) : base(context)
        {
        }

        public async Task<InventoryResult?> GetInventoryById(long Id)
        {
            return await Context.inventories.Where(r => r.Id == Id)

                .Select(i => new InventoryResult()
                {
                    Count = i.Count,
                    Id=i.Id,
                    Price = i.Price,    
                    ProductId=i.ProductId,
                    SellerId=i.SellerId
                }).FirstOrDefaultAsync();
           
            
        }
    }
}
