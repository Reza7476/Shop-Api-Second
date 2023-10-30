using Common.Application;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Seller.Edit
{
    public record EditSellerCommand(long Id,string ShopName, string NationalCode) :IBaseCommand;
}
