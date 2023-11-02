using Common.Application;
using Shop.Domain.UserAggregate;
using Shop.Domain.UserAggregate.Repository;

namespace Shop.Application.Users.ChargeWallet
{
    public class ChargeUserWalletCommandHandler : IBaseCommandHandler<ChargeUserWalletCommand>
    {
        IUserRepository _repository;

        public ChargeUserWalletCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> Handle(ChargeUserWalletCommand request, CancellationToken cancellationToken)
        {

            var user = await _repository.GetTracking(request.UserId);
            if (user == null)

                return OperationResult.NotFound();
            var wallet = new UserWallet(request.Price,request.Description,request.IsFinally,request.Type);
            user.CharegWallet(wallet);
            await _repository.Save();
            return OperationResult.Success();
        }
    }


    
}
