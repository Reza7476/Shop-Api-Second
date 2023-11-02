using Common.Application;
using Shop.Domain.SellerAggregate;
using Shop.Domain.SellerAggregate.Repository;
using Shop.Domain.SellerAggregate.Services;

namespace Shop.Application.Sellers.Create
{
    public class CreateSellerCommandHandler : IBaseCommandHandler<CreateSellerCommand>
    {

        private readonly ISellerRepository _repository;
        private readonly ISellerDomainService _domainService;

        public CreateSellerCommandHandler(ISellerRepository repository, ISellerDomainService domainService)
        {
            _repository = repository;
            _domainService = domainService;
        }

        public async Task<OperationResult> Handle(CreateSellerCommand request, CancellationToken cancellationToken)
        {
            var seller = new SellerAgg(request.UserId, request.ShopName
                , request.NatiaonalCode, _domainService);
            _repository.Add(seller);
            await _repository.Save();
            return OperationResult.Success();
        }
    }




}
