using Common.Application;
using Shop.Domain.OrderAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain.Repository;

namespace Shop.Application.Orders.CheckOut
{
    public class CheckOutOrderCommand : IBaseCommand
    {
       

        public long UserId { get; private set; }
        public string Province { get; private set; }
        public string City { get; private set; }
        public string PostalCode { get; private set; }
        public string PostalAddress { get; private set; }
        public string Name { get; private set; }
        public string Family { get; private set; }

        public string PhoneNumber { get; private set; }

        public string NationalCode { get; private set; }
        public CheckOutOrderCommand(long userId, string province, string city, string postalCode,
           string postalAddress, string name, string family, string phoneNumber, string nationalCode)
        {
            UserId = userId;
            Province = province;
            City = city;
            PostalCode = postalCode;
            PostalAddress = postalAddress;
            Name = name;
            Family = family;
            PhoneNumber = phoneNumber;
            NationalCode = nationalCode;
        }
    }
}
