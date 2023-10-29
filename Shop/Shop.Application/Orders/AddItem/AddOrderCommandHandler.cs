using Common.Application;
using Shop.Domaion.OrderAggregate;
using Shop.Domaion.OrderAggregate.Repositiory;
using Shop.Domaion.SellerAggregate.Repository;

namespace Shop.Application.Orders.AddItem
{
    public class AddOrderCommandHandler : IBaseCommandHandler<AddOrderCommand>
    {

        private readonly IOrderRepositiory _repository;
        private readonly ISellerRepository _sellerRepository;
        public AddOrderCommandHandler(IOrderRepositiory repository, ISellerRepository sellerRepository = null)
        {
            _repository = repository;
            _sellerRepository = sellerRepository;
        }

        public async Task<OperationResult> Handle(AddOrderCommand request, CancellationToken cancellationToken)
        {


            var inventory = await _sellerRepository.GetInventoryById(request.InventoryId);
            if (inventory == null) 
                return OperationResult.NotFound();

            if (inventory.Count < request.Count)
                return OperationResult.Error("تعداد محصولات موجود کمتر از حد درخواستی است");

            var order = await _repository.GetCurrentUserOrder(request.UserId);
            if (order == null)
                order = new OrderAgg(request.UserId);

            order.AddItem(new OrderItemAgg(request.InventoryId, request.Count, inventory.Price));
           
            if(ItemCountBiggerThanInventoryCount(inventory,order))
                return OperationResult.Error("تعداد محصولات موجود کمتر از حد درخواستی است");
            
            await _repository.Save();
            return OperationResult.Success();
        }


        private bool ItemCountBiggerThanInventoryCount(InventoryResult inventory,OrderAgg order)
        {

            var orderItem = order.Items.FirstOrDefault(f => f.InventoryId == inventory.Id);
            if(orderItem.Count> inventory.Count)
                return true;

           return  false;
        }
    }

}
