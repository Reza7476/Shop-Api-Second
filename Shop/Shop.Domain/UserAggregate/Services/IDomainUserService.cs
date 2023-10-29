using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domaion.UserAggregate.Services
{
    public interface IDomainUserService
    {
        bool IsEmailExist(string email);
        bool IsPhoneNumberExist(string phoneNumber);

    }
}
