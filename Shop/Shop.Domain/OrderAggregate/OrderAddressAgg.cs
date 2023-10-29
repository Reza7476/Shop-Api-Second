using Common.Domain;

namespace Shop.Domaion.OrderAggregate
{
    public class OrderAddressAgg:BaseEntity
    {
        public OrderAddressAgg(string province, string city, string postalCode, string postalAddress, string name, string family, string phoneNumber, string nationalCode)
        {
            Province = province;
            City = city;
            PostalCode = postalCode;
            PostalAddress = postalAddress;
            Name = name;
            Family = family;
            PhoneNumber = phoneNumber;
            NationalCode = nationalCode;
           
        }

        public long OrdreId { get;internal set; }
        public string Province { get; private set; }
        public string City { get; private set; }
        public string PostalCode { get; private set; }
        public string PostalAddress { get; private set; }
        public string Name { get; private set; }
        public string Family { get; private set; }

        public string PhoneNumber { get; private set; }

        public string NationalCode { get; private set; }
       

        public OrderAgg Order { get; set; }
    }


}
