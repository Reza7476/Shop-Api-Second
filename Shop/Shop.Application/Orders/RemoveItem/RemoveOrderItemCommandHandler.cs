using Common.Application;
using Shop.Domain.OrderAggregate.Repositiory;

namespace Shop.Application.Orders.RemoveItem
{
    public class RemoveOrderItemCommandHandler:IBaseCommandHandler<RemoveOrderItemCommand>
    {

      private readonly  IOrderRepositiory _repository;

        public RemoveOrderItemCommandHandler(IOrderRepositiory repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> Handle(RemoveOrderItemCommand request, CancellationToken cancellationToken)
        {

            var currentOrder = await _repository.GetCurrentUserOrder(request.UserId);
            if (currentOrder == null)
                return OperationResult.NotFound();
            currentOrder.RemoveItem(request.ItemId);
            _repository.Save();
            return OperationResult.Success();
        }
    }


    
}
