using Dapper;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.SellerAggregate;
using Shop.Domain.SellerAggregate.Repository;
using Shop.Infrustructure._Utilities;
using Shop.Infrustructure.Persistant.Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrustructure.Persistant.Ef.SellerAggregate
{
    internal class SellerRepository : BaseReepository<SellerAgg>, ISellerRepository
    {

        DapperContext _dapperContext;
        public SellerRepository(ShopContext context, DapperContext dapperContext) : base(context)
        {
            _dapperContext = dapperContext;
        }

        //public async Task<InventoryResult?> GetInventoryById(long Id)
        //{
        //    return await Context.inventories.Where(r => r.Id == Id)

        //        .Select(i => new InventoryResult()
        //        {
        //            Count = i.Count,
        //            Id=i.Id,
        //            Price = i.Price,    
        //            ProductId=i.ProductId,
        //            SellerId=i.SellerId
        //        }).FirstOrDefaultAsync();


        //}


        public async Task<InventoryResult?> GetInventoryById(long Id)
        {
            using var connection=_dapperContext.CreateConnection();

            var sql = $"SELECT * from{_dapperContext.Inventories} where Id=@inventoryId";
            return  await connection
                .QueryFirstOrDefaultAsync<InventoryResult>(sql, new { inventoryId = Id });
        }
    }
}
