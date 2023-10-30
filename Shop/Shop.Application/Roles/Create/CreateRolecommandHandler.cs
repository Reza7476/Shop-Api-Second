using Common.Application;
using Shop.Domain.RoleAggregate;
using Shop.Domain.RoleAggregate.Repository;

namespace Shop.Application.Roles.Create
{
    public class CreateRolecommandHandler:IBaseCommandHandler<CreateRolecommand>
    {

       private readonly IRoleRepository _repository;

        public CreateRolecommandHandler(IRoleRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> Handle(CreateRolecommand request, CancellationToken cancellationToken)
        {
            

            var permissions=new List<RolePermissionAgg>();

            request.Permission.ForEach(f =>
            {
                permissions.Add(new RolePermissionAgg(f));
            });


            var role=new RoleAgg(request.Title, permissions);

           await _repository.AddAsync(role);
           await _repository.Save();

            return OperationResult.Success();

        }
    }

}
