using Common.Domain;
using Common.Domain.Exceptions;
using Shop.Domaion.SellerAggregate.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domaion.SellerAggregate
{
    public class SellerAgg : AggregateRoot
    {


        public long UserId { get; private set; }
        public string ShopName { get; private set; }
        public string NatiaonalCode { get; private set; }
        public SellerStatus Status { get; private set; }
        public List<SellerInventoryAgg> Inventories { get; private set; }
        public DateTime? LastUpdate { get; internal set; }

        public SellerAgg(long userId, string shopName, string natiaonalCode)
        {
            Guard(shopName, natiaonalCode);
            UserId = userId;
            ShopName = shopName;
            NatiaonalCode = natiaonalCode;

            Inventories = new List<SellerInventoryAgg>();
        }
        private SellerAgg()
        {

        }


        public void AddInventory(SellerInventoryAgg inventory)
        {
            if (Inventories.Any(f => f.ProductId == inventory.ProductId))

                throw new InvalidDomainDataException("این محصول قبلا ثبت شده است.");


            Inventories.Add(inventory);
        }

        public void EditInventory(SellerInventoryAgg newInventory)
        {
            var currentInventory = Inventories.FirstOrDefault(f => f.Id == newInventory .Id);
            if (currentInventory == null)
                throw new NullOrEmptyDomainDataException("محصول یافت نشد");
            Inventories.Remove(currentInventory);
            Inventories.Add(newInventory);


        }

        public void DeletInventory(long inventoryId)
        {
            var inventory = Inventories.FirstOrDefault(f => f.Id == inventoryId);
            if (inventory == null)
                throw new NullOrEmptyDomainDataException("محصول یافت نشد");

            Inventories.Remove(inventory); 
            
        }
        public void ChangeStatus(SellerStatus status)
        {
            Status = status;
            LastUpdate = DateTime.Now;
        }
        public void Edit(string shopName, string nationalCode)
        {
            Guard(shopName, nationalCode);
            ShopName = shopName;
            NatiaonalCode = nationalCode;

        }
        public void Guard(string shopName, string nationalCode)
        {
            NullOrEmptyDomainDataException.CheckString(shopName, nameof(shopName));
            NullOrEmptyDomainDataException.CheckString(nationalCode, nameof(nationalCode));

            if (IranianNationaCodeChecker.IsValid(nationalCode) == false)
                throw new InvalidDomainDataException("کد ملی نامعتبر است ");
        }

    }
}
