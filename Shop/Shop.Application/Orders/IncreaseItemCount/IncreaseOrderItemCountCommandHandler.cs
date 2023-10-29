using Common.Application;
using Shop.Domain.OrderAggregate.Repositiory;

namespace Shop.Application.Orders.IncreaseItemCount
{
    public class IncreaseOrderItemCountCommandHandler : IBaseCommandHandler<IncreaseOrderItemCountCommand>
    {

       private readonly IOrderRepositiory _repository;

        public IncreaseOrderItemCountCommandHandler(IOrderRepositiory repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> Handle(IncreaseOrderItemCountCommand request, CancellationToken cancellationToken)
        {
           var currentOrder=await _repository.GetCurrentUserOrder(request.UserId);
            if (currentOrder == null)

                return OperationResult.NotFound();

            currentOrder.IcreaseItemCount(request.ItemId, request.Count);

            _repository.Save();
            return OperationResult.Success();
        }
    }
}
