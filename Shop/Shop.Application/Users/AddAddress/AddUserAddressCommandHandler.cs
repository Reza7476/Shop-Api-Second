using Common.Application;
using Shop.Domain.UserAggregate;
using Shop.Domain.UserAggregate.Repository;
using Shop.Domain.UserAggregate.Services;

namespace Shop.Application.Users.AddAddress
{
    public class AddUserAddressCommandHandler : IBaseCommandHandler<AddUserAddressCommand>
    {

        IUserRepository _repository;
        IDomainUserService _domainService;
        public AddUserAddressCommandHandler(IUserRepository repository, IDomainUserService domainService)
        {
            _repository = repository;
            _domainService = domainService;
        }

        public async Task<OperationResult> Handle(AddUserAddressCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetTracking(request.UserId);
            if (user == null) return OperationResult.NotFound();
            var address=new UserAddress(request.Province,request.City,request.PostalCode,request.Name,request.Family,request.PostalAddress,
                request.PhoneNumber,request.NationalCode);
            user.AddAddress(address);

            await _repository.Save();
            return OperationResult.Success();
        }
    }
}