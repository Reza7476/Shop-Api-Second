using Common.Domain;
using Shop.Domain.RoleAggregate.Enums;

namespace Shop.Domain.RoleAggregate
{
    public class RolePermissionAgg : BaseEntity
    {
        public long RoleAggTd { get; set; }
        public RolePermission RolePermissio { get; set; }
    }


}
