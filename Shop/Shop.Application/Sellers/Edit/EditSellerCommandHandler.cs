using Common.Application;
using Shop.Domain.SellerAggregate.Repository;
using Shop.Domain.SellerAggregate.Services;

namespace Shop.Application.Sellers.Edit
{
    public class EditSellerCommandHandler : IBaseCommandHandler<EditSellerCommand>
    {
        ISellerRepository _repository;
        ISellerDomainService _domainService;

        public EditSellerCommandHandler(ISellerRepository repository, ISellerDomainService domainService)
        {
            _repository = repository;
            _domainService = domainService;
        }

        public async Task<OperationResult> Handle(EditSellerCommand request, CancellationToken cancellationToken)
        {

            var seller = await _repository.GetTracking(request.Id);
            if (seller == null)
                return OperationResult.Success();
            seller.Edit(request.ShopName, request.NationalCode, _domainService);
            seller.ChangeStatus(request.Status);

            _repository.Save();


            return OperationResult.Success();
        }
    }
}
