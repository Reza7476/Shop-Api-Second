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
    public class UserAgg : AggregateRoot
    {

      
        public UserAgg(string name, string family, string phoneNumber, string email,
            string password, Gender gender, IDomainUserService domainSrvice)
        {
            Name = name;
            Family = family;
            PhoneNumber = phoneNumber;
            Email = email;
            Password = password;
            Gender = gender;
            AvatarName = "Avatar.png";
            IsActive = true;
            Roles = new();
            wallets = new();
            Addresses = new();
            Guard(phoneNumber, email, domainSrvice);

        }

        public string Name { get; private set; }
        public string Family { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string AvatarName { get;  set; }
        public bool IsActive { get; set; }

        public Gender Gender { get; private set; }
        //public IDomainUserService DomainSrvice { get; }
        public List<UserRoles> Roles { get; private set; }
        public List<UserAddress> Addresses { get; private set; }
        public List<UserWallet> wallets { get; set; }


        public void Edit(string name,
            string family, string phoneNumber, string email, 
           Gender gender, IDomainUserService domainSrvice)
        {


            Guard(phoneNumber, email, domainSrvice);
            Name = name;
            Family = family;
            PhoneNumber = phoneNumber;
            Email = email;
            Gender = gender;
        }




        public static UserAgg RegisterUser( string phoneNumber, string password, IDomainUserService domainService)
        {

            return new UserAgg("", "", phoneNumber, null, password, Gender.None, domainService);
        }
       
        public void SetAvatar(string imageName)
        {
            if (string.IsNullOrWhiteSpace(imageName))
                imageName = "Avatar.png";
            AvatarName = imageName;
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

       


      
    }
}
