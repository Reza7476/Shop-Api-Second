using Common.Application;
using Shop.Domain.OrderAggregate.Repositiory;

namespace Shop.Application.Orders.DecreaseItemCount
{
    public class DecreaseItemCountCommandHandler : IBaseCommandHandler<DecreaseItemCountCommand>
    {

        IOrderRepositiory _repository;

        public DecreaseItemCountCommandHandler(IOrderRepositiory repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> Handle(DecreaseItemCountCommand request, CancellationToken cancellationToken)
        {

            var currentOrder = await _repository.GetCurrentUserOrder(request.UserId);
            if (currentOrder == null)
                return OperationResult.NotFound();
            currentOrder.DecreaseItemCount(request.ItemId,request.Count);
            _repository.Save();
            return OperationResult.Success();   
        }
    }


}
