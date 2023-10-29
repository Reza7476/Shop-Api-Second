using Common.Domain;
using Common.Domain.Exceptions;

namespace Shop.Domain.UserAggregate
{
    public class UserAddress : BaseEntity
    {
        public UserAddress(string province, string city, string postalCode, string name, string family, string postalAddress, string phoneNumber, string nationalCode, bool activAddress)
        {
            Guard(province, city, postalCode, name, family, postalAddress, phoneNumber, nationalCode);
            Province = province;
            City = city;
            PostalCode = postalCode;
            Name = name;
            Family = family;
            PostalAddress = postalAddress;
            PhoneNumber = phoneNumber;
            NationalCode = nationalCode;
            ActivAddress = false;
        }

        public long UserId { get; internal set; }
        public string Province { get; private set; }
        public string City { get; private set; }
        public string PostalCode { get; private set; }
        public string PostalAddress { get; private set; }
        public string Name { get; private set; }
        public string Family { get; private set; }

        public string PhoneNumber { get; private set; }

        public string NationalCode { get; private set; }
        public bool ActivAddress { get; private set; }



        public void SetActive()
        {
            ActivAddress = true;
        }
        public void Edit(string province, string city, string postalCode, string name, string family, string postalAddress, string phoneNumber, string nationalCode)
        {
            Guard(province, city, postalCode, name, family, postalAddress, phoneNumber, nationalCode);
            Province = province;
            City = city;
            PostalCode = postalCode;
            Name = name;
            Family = family;
            PostalAddress = postalAddress;
            PhoneNumber = phoneNumber;
            NationalCode = nationalCode;

        }

        public void Guard(string province, string city, string postalCode, string name, string family, string postalAddress, string phoneNumber, string nationalCode)
        {
            NullOrEmptyDomainDataException.CheckString(Province, nameof(Province));
            NullOrEmptyDomainDataException.CheckString(city, nameof(city));
            NullOrEmptyDomainDataException.CheckString(postalCode, nameof(postalCode));
            NullOrEmptyDomainDataException.CheckString(name, nameof(name));
            NullOrEmptyDomainDataException.CheckString(family, nameof(family));
            NullOrEmptyDomainDataException.CheckString(postalAddress, nameof(postalAddress));
            if (IranianNationaCodeChecker.IsValid(nationalCode) == false)
                throw new InvalidDomainDataException("کد ملی نا معتبر است");
        }

    }
}
