using Common.Application;
using Shop.Domain.UserAggregate;
using Shop.Domain.UserAggregate.Repository;
using Shop.Domain.UserAggregate.Services;

namespace Shop.Application.Users.Register
{
    public class gisterUserCommandHandler : IBaseCommandHandler<RegisterUserCommand>
    {

       private readonly IUserRepository _repository;
       private readonly IDomainUserService _domainService;
        public gisterUserCommandHandler(IUserRepository repository, IDomainUserService domainService)
        {
            _repository = repository;
            _domainService = domainService;
        }

        public async Task<OperationResult> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {



            var user = UserAgg.RegisterUser(request.PhoneNumber, request.Password,_domainService);
            _repository.Add(user);
             await _repository.Save();
            return OperationResult.Success();


        }
    }
}
