using Common.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Seller.Create
{
    public class CreateSellerCommand : IBaseCommand
    {
        public CreateSellerCommand(long userId, string shopName, string natiaonalCode)
        {
            UserId = userId;
            ShopName = shopName;
            NatiaonalCode = natiaonalCode;
        }

        public long UserId { get; private set; }
        public string ShopName { get; private set; }
        public string NatiaonalCode { get; private set; }
    }




}
