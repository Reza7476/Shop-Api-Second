using Common.Domain.Repository;
using Shop.Domain.SellerAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.SellerAggregate.Repository
{
    public interface ISellerRepository : IBaseRepository<SellerAgg>
    {

        Task<InventoryResult> GetInventoryById(long Id);
    }
    public class InventoryResult
    {
        public long Id { get; set; }
        public long SellerId { get; set; }
        public long ProductId { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }
    }
}
