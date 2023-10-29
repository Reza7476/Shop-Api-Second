using Common.Domain;

namespace Shop.Domaion.OrderAggregate.ValueObjects
{
    public class OrderDiscount : ValueObject
    {
        public OrderDiscount(string discountTitle, int discountAmount)
        {
            DiscountTitle = discountTitle;
            DiscountAmount = discountAmount;
        }

        public string DiscountTitle { get; set; }
        public int DiscountAmount { get; private set; }
    }


}
