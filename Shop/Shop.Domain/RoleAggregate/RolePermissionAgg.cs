using Common.Domain;
using Shop.Domaion.RoleAggregate.Enums;

namespace Shop.Domaion.RoleAggregate
{
    public class RolePermissionAgg:BaseEntity
    {
        public long  RoleAggTd { get;  set; }
        public RolePermission RolePermissio { get;  set; }
    }


}
