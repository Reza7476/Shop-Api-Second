using Common.Application;
using Shop.Domain.UserAggregate.Repository;

namespace Shop.Application.Users.DeleteAddress
{
    public class DeleteUserAddressCommandHandler : IBaseCommandHandler<DeleteUserAddressCommand>
    {
        IUserRepository _repository;

        public DeleteUserAddressCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async  Task<OperationResult> Handle(DeleteUserAddressCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetTracking(request.UserId);
            if (user == null)
                return OperationResult.NotFound();

            user.DeleteAddress(request.AddressId);


             await _repository.Save();
            return OperationResult.Success();
        }
    }

   
}
