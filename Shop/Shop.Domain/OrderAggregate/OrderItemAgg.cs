using Common.Domain;
using Common.Domain.Exceptions;

namespace Shop.Domain.OrderAggregate
{
    public class OrderItemAgg : BaseEntity
    {
        public OrderItemAgg(long inventoryId, int count, int price)
        {
            PriceGuard(price);
            CountGuard(count);
            InventoryId = inventoryId;
            Count = count;
            Price = price;
        }

        public long OrderItem { get; internal set; }

        public long InventoryId { get; private set; }
        public int Count { get; private set; }
        public int Price { get; private set; }
        public int TotalPrice => Price * Count;



        public void ChangeCount(int newCount)
        {
            CountGuard(newCount);
            if (newCount < 1)
                return;
            Count = newCount;

        }
        public void SetPrice(int newPrice)
        {
            PriceGuard(newPrice);
            Price = newPrice;
        }


        public void PriceGuard(int newPrice)
        {
            if (newPrice < 1)
            {
                throw new InvalidDomainDataException("مبلغ کالا نامعتبر است");
            }
        }



        public void CountGuard(int count)
        {
            if (count < 1)
                throw new InvalidDomainDataException();
        }


        public void IncreaseCount(int count)
        {
            Count += count;

        }
        public void DecreaseCount(int count)
        {

            if (Count == 1)

                return;
            if (Count - count <= 0)
                return;

            Count -= count;

        }
    }


}
