using Common.Domain;
using Common.Domain.Exceptions;
using Shop.Domain.UserAggregate.Enums;
using Shop.Domain.UserAggregate.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Shop.Domain.UserAggregate
{
    public class User : AggregateRoot
    {
        public User(string name, string family, string phoneNumber, string email, string password, string avatorName, Gender gender, IDomainUserService domainSrvice)
        {
            Name = name;
            Family = family;
            PhoneNumber = phoneNumber;
            Email = email;
            Password = password;
            AvatorName = avatorName;

            Gender = gender;
            Guard(phoneNumber, email, domainSrvice);

        }

        public string Name { get; private set; }
        public string Family { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string AvatorName { get; private set; }
        public string IsActive { get; set; }

        public Gender Gender { get; private set; }
        public List<UserRoles> Roles { get; private set; }
        public List<UserAddress> Addresses { get; private set; }
        public List<UserWallet> wallets { get; set; }


        public void Edit(string name, string family, string phoneNumber, string email, string avatorName, Gender gender, IDomainUserService domainSrvice)
        {


            Guard(phoneNumber, email, domainSrvice);
            Name = name;
            Family = family;
            PhoneNumber = phoneNumber;
            Email = email;
            AvatorName = avatorName;
            Gender = gender;
        }

        public void AddAddress(UserAddress address)
        {
            address.UserId = Id;
            Addresses.Add(address);
        }
        public void EditAddress(UserAddress address)
        {
            var oldaddress = Addresses.FirstOrDefault(f => f.Id == address.Id);
            if (oldaddress != null)

                throw new NullOrEmptyDomainDataException("Address Not Found");


            Addresses.Remove(oldaddress);
            Addresses.Add(address);
        }

        public void DeleteAddress(long addressId)
        {
            var oldaddress = Addresses.FirstOrDefault(f => f.Id == addressId);
            if (oldaddress != null)
                throw new NullOrEmptyDomainDataException("Address Not Found");
            Addresses.Remove(oldaddress);
        }

        public void CharegWallet(UserWallet wallet)
        {
            wallets.Add(wallet);
        }

        public void SetRoles(List<UserRoles> roles)
        {
            Roles.ForEach(f => f.UserId = Id);
            Roles.Clear();
            Roles.AddRange(roles);
        }

        public void Guard(string phoneNumber, string email, IDomainUserService domainService)
        {
            NullOrEmptyDomainDataException.CheckString(phoneNumber, nameof(phoneNumber));
            NullOrEmptyDomainDataException.CheckString(email, nameof(email));
            if (phoneNumber.Length != 11)
                throw new InvalidDomainDataException("شماره موبایل نا معتبر است");

            if (email.IsValidEmail() == false)
                throw new InvalidDomainDataException("ایمیل نا معتبر است");
            if (phoneNumber != PhoneNumber)
                if (domainService.IsPhoneNumberExist(phoneNumber))
                    throw new InvalidDomainDataException("شماره تلفن تکراری است");
            if (email != Email)
                if (domainService.IsEmailExist(email))
                    throw new InvalidDomainDataException("ایمیل تکراری است");

        }




        public static User RegisterUser(string email, string phoneNumber, string password, IDomainUserService domainService)
        {
            return new User("", "", phoneNumber, email, password, "", Gender.None, domainService);
        }
    }
}
