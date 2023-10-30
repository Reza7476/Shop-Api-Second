using Common.Application;
using Shop.Domain.RoleAggregate;
using Shop.Domain.RoleAggregate.Repository;

namespace Shop.Application.Roles.Edit
{
    public class EditRoleCommandHandler : IBaseCommandHandler<EditRoleCommand>
    {

       private readonly IRoleRepository _repository;
        public  async Task<OperationResult> Handle(EditRoleCommand request, CancellationToken cancellationToken)
        {
            var role = await _repository.GetTracking(request.Id);
            if (role == null)
                return OperationResult.NotFound();
            role.Edit(request.Title);
            var permissions = new List<RolePermissionAgg>();
            request.Permission.ForEach(f =>
            {
                permissions.Add(new RolePermissionAgg(f));  
            });

            role.SetPermission(permissions);
           await _repository.Save();

            return OperationResult.Success();
        }
    }
}
