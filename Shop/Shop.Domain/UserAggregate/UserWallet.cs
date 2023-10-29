using Common.Domain;
using Common.Domain.Exceptions;
using Shop.Domain.UserAggregate.Enums;

namespace Shop.Domain.UserAggregate
{
    public class UserWallet : BaseEntity
    {
        public UserWallet(int price, string description, bool isFinally,
            DateTime? finalDate, WalletType type)
        {
            if (price < 1000) throw new InvalidDomainDataException();
            Price = price;
            Description = description;
            IsFinally = isFinally;
            FinalDate = finalDate;
            Type = type;
        }

        public long UserId { get; internal set; }
        public int Price { get; private set; }
        public string Description { get; private set; }
        public bool IsFinally { get; private set; }
        public DateTime? FinalDate { get; private set; }
        public WalletType Type { get; private set; }

        public void Finally(string refCodde)
        {
            IsFinally = true;
            FinalDate = DateTime.Now;
            Description += $"کدپیگیری :{refCodde}";

        }

        public void Finaly()
        {
            IsFinally = true;
            FinalDate = DateTime.Now;
        }
    }
}
