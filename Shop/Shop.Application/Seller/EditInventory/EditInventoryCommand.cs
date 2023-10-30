using Common.Application;
using FluentValidation;
using Shop.Domain.SellerAggregate.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Seller.EditInventory
{
    public class EditInventoryCommand:IBaseCommand
    {
        public EditInventoryCommand(long InventoryId, long sellerId,
            int count, int price, int? persentageDiscount)
        {
            SellerId = sellerId;
            Count = count;
            Price = price;
            PersentageDiscount = persentageDiscount;
        }

        public long SellerId { get; internal set; }
        public long InventoryId { get; private set; }
        public int Count { get; private set; }
        public int Price { get; private set; }
        public int? PersentageDiscount { get; private set; }
    }

    public class EditInventoryCommandHandler : IBaseCommandHandler<EditInventoryCommand>
    {

        ISellerRepository _repository;

        public EditInventoryCommandHandler(ISellerRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> Handle(EditInventoryCommand request, CancellationToken cancellationToken)
        {
        
        var seller= await _repository.GetTracking(request.InventoryId);
            if (seller == null)
                return OperationResult.NotFound();
          
            seller.EditInventory(request.InventoryId,request.Count,request.Price,request.PersentageDiscount);
           await _repository.Save();

            return OperationResult.Success();
        }
    }

    public class EditInventoryCommandValidator:AbstractValidator<EditInventoryCommand>
    {
    }
}
