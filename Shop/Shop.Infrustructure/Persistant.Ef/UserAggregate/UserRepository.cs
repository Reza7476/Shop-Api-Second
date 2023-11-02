using Shop.Domain.UserAggregate;
using Shop.Domain.UserAggregate.Repository;
using Shop.Infrustructure._Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrustructure.Persistant.Ef.UserAggregate
{
    internal class UserRepository : BaseReepository<UserAgg>, IUserRepository
    {
        public UserRepository(ShopContext context) : base(context)
        {
        }
    }
}
