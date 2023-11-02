using Common.Application;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Users.DeleteAddress
{
    public record DeleteUserAddressCommand(long UserId,long AddressId):IBaseCommand;

   
}
