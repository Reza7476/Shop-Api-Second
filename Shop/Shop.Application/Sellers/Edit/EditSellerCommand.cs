using Common.Application;
using FluentValidation.Validators;
using Shop.Domain.SellerAggregate.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Sellers.Edit
{
    public record EditSellerCommand(long Id, string ShopName, string NationalCode, SellerStatus Status) : IBaseCommand;
}
