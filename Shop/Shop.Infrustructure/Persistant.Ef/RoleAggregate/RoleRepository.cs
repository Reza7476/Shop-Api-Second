using Shop.Domain.RoleAggregate;
using Shop.Domain.RoleAggregate.Repository;
using Shop.Infrustructure._Utilities;

namespace Shop.Infrustructure.Persistant.Ef.RoleAggregate
{
    internal class RoleRepository : BaseReepository<RoleAgg>, IRoleRepository
    {
        public RoleRepository(ShopContext context) : base(context)
        {
        }
    }
}
