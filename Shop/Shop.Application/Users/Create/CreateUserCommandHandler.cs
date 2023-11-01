using Common.Application;
using Shop.Domain.UserAggregate;
using Shop.Domain.UserAggregate.Repository;
using Common.Application.SecurityUtil;
using Shop.Domain.UserAggregate.Services;

namespace Shop.Application.Users.Create
{
    public class CreateUserCommandHandler : IBaseCommandHandler<CreateUserCommand>
    {

        IUserRepository _repository;
        IDomainUserService _domainService;
        public CreateUserCommandHandler(IUserRepository repository, IDomainUserService domainService)
        {
            _repository = repository;
            _domainService = domainService;
        }

        public async Task<OperationResult> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var passsword=Sha256Hasher.Hash(request.Password);
            var user=new UserAgg(request.Name,request.Family,request.PhoneNumber,
                request.Email,passsword, request.Gender,_domainService);
              


            _repository.Add(user);
           await _repository.Save();
            return OperationResult.Success();
        }
    }

}
