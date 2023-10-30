using Common.Application;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Seller.AddInventory
{
    public class AddInventoryCommand:IBaseCommand
    {
        public AddInventoryCommand(long sellerId, long productId,
            int count, int price, int? persentageDiscount)
        {
            SellerId = sellerId;
            ProductId = productId;
            Count = count;
            Price = price;
            PersentageDiscount = persentageDiscount;
        }

        public long SellerId { get; internal set; }
        public long ProductId { get; private set; }
        public int Count { get; private set; }
        public int Price { get; private set; }
        public int? PersentageDiscount { get; private set; }


    }

}
