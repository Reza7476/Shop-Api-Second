using Common.Application;
using Shop.Domain.SellerAggregate;
using Shop.Domain.SellerAggregate.Repository;

namespace Shop.Application.Seller.AddInventory
{
    public class AddInventoryCommandHandler : IBaseCommandHandler<AddInventoryCommand>
    {
        ISellerRepository _repository;

        public AddInventoryCommandHandler(ISellerRepository repository)
        {
            _repository = repository;
        }

        public  async Task<OperationResult> Handle(AddInventoryCommand request, CancellationToken cancellationToken)
        {
            var seller=await _repository.GetTracking(request.SellerId);
            if (seller == null)
                return OperationResult.NotFound();
            var inventory=new SellerInventoryAgg(request.ProductId, request.Count,request.Price,request.PersentageDiscount);
            seller.AddInventory(inventory);

           await _repository.Save();

            return OperationResult.Success();
        }
    }

}
