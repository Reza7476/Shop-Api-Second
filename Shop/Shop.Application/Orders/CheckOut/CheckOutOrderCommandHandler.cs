using Common.Application;
using Shop.Domain.OrderAggregate;
using Shop.Domain.OrderAggregate.Repositiory;

namespace Shop.Application.Orders.CheckOut
{
    public class CheckOutOrderCommandHandler : IBaseCommandHandler<CheckOutOrderCommand>
    {
      private readonly  IOrderRepositiory _repository;
        public CheckOutOrderCommandHandler(IOrderRepositiory repository)
        {
            _repository = repository;
        }
        public async Task<OperationResult> Handle(CheckOutOrderCommand request, CancellationToken cancellationToken)
        {
            var currentOrder = await _repository.GetCurrentUserOrder(request.UserId);
            if (currentOrder == null)
                return OperationResult.NotFound();

            var address = new OrderAddressAgg(request.Province, request.City, request.PostalAddress, request.PostalCode,
                request.Name, request.Family,
                request.PhoneNumber, request.NationalCode);
            currentOrder.CheckOut(address);
            _repository.Save();
            return OperationResult.Success();
        }
    }
}
