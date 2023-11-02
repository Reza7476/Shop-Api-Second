using Common.Domain.Repository;
using Shop.Domain.CommentAggregate;
using Shop.Infrustructure._Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrustructure.Persistant.Ef.CommentAggregate
{
    public class CommentRepository : BaseReepository<CommentAgg>, ICommentRepositoey
    {
        public CommentRepository(ShopContext context) : base(context)
        {
        }

        public async Task DeleteAndSave(CommentAgg comment)
        {
            Context.Remove(comment);
            await Context.SaveChangesAsync();   
        }
    }
}
