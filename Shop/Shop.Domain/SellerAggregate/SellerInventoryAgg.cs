using Common.Domain;
using Common.Domain.Exceptions;

namespace Shop.Domain.SellerAggregate
{
    public class SellerInventoryAgg : BaseEntity
    {
        public SellerInventoryAgg(long productId, int count, int price, int? persentageDiscount)
        {


            if (price < 1 || count < 0)
                throw new InvalidDomainDataException();
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


        public void Edit(int count, int price, int? persentageDiscount)
        {

            if (price < 1 || count < 0)
                throw new InvalidDomainDataException();
            Count = count;
            Price = price;
            PersentageDiscount = persentageDiscount;
        }
    }
    }
}
