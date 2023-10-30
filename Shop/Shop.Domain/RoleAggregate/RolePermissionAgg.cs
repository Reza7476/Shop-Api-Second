using Common.Domain;
using Shop.Domain.RoleAggregate.Enums;

namespace Shop.Domain.RoleAggregate
{
    public class RolePermissionAgg : BaseEntity
    {
        public RolePermissionAgg(RolePermission rolePermissio)
        {
            RolePermissio = rolePermissio;
        }

        public long RoleAggTd { get; internal set; }
        public RolePermission RolePermissio { get;private set; }
    }


}
