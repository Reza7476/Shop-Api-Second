using Common.Domain;
using Common.Domain.Exceptions;
using Shop.Domain.OrderAggregate.Enums;
using Shop.Domain.OrderAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.OrderAggregate
{
    public class OrderAgg : AggregateRoot
    {
        private OrderAgg()
        {

        }
        public OrderAgg(long userId)
        {
            UserId = userId;
            Status = OrderStatus.Pennding;
            Items = new List<OrderItemAgg>();
        }

        public long UserId { get; private set; }
        public OrderStatus Status { get; set; }
        public OrderDiscount? Discount { get; set; }
        public OrderAddressAgg? Address { get; private set; }
        public List<OrderItemAgg> Items { get; private set; }
        public DateTime? LastUpdate { get; set; }
        public int ItemCount => Items.Count;
        public OrderShippingMethod? ShippingMethod { get; set; }

        public int TotalPrice
        {
            get
            {
                var totalPrice = Items.Sum(f => f.TotalPrice);

                if (ShippingMethod != null)
                    totalPrice += ShippingMethod.ShippingCost;
                if (Discount != null)
                    totalPrice -= Discount.DiscountAmount;
                return totalPrice;
            }
        }




        public void AddItem(OrderItemAgg item)
        {
            ChangeOrderGuard();
            var oldItem = Items.FirstOrDefault(f => f.InventoryId == item.InventoryId);
            if (oldItem != null)
            {
                oldItem.ChangeCount(item.Count + oldItem.Count);
                return;
            }
            Items.Add(item);
        }

        public void RemoveItem(long itemId)
        {
            ChangeOrderGuard();
            var currentItem = Items.FirstOrDefault(f => f.Id == itemId);
            if (currentItem != null)
            {
                Items.Remove(currentItem);
            }
        }
        public void ChangeCountItem(int itemId, int newCount)
        {

            ChangeOrderGuard();
            var currentItem = Items.FirstOrDefault(f => f.Id == itemId);
            if (currentItem == null)
                throw new NullOrEmptyDomainDataException();
          
            currentItem.ChangeCount(newCount);
        }

        public void DecreaseItemCount(long itemId, int count)
        {
            ChangeOrderGuard();
            var currentItem = Items.FirstOrDefault(f => f.Id == itemId);
            if (currentItem == null)
                throw new InvalidDomainDataException();
            currentItem.DecreaseCount(count);
        }
       
        
        public void IcreaseItemCount(long itemId, int count)
        {
             ChangeOrderGuard();
            var currentItem = Items.FirstOrDefault(f => f.Id == itemId);


            if (currentItem == null)
                throw new NullOrEmptyDomainDataException();
            currentItem.IncreaseCount(count);
        }
        public void ChangeStatus(OrderStatus status)
        {
            Status = status;
            LastUpdate = DateTime.Now;
        }

        public void Finally()
        {
            
        }

        public void CheckOut(OrderAddressAgg orderAddress,OrderShippingMethod shippingMethod)
        {
            ChangeOrderGuard();
            Address = orderAddress;

            ShippingMethod = shippingMethod;    
        }


       public void ChangeOrderGuard()
        {
            if (Status != OrderStatus.Pennding)
                throw new InvalidDomainDataException("امکان ثبت محصول د راین سفارش وجود ندارد");
        }



    }


}
