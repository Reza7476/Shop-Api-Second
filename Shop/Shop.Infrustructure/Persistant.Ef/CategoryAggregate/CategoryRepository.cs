using Common.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.CategoryAggreagate;
using Shop.Infrustructure._Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrustructure.Persistant.Ef.CategoryAggregate
{



    internal class CategoryRepository : BaseReepository<CategoryAgg>, ICategoryRepository
    {
        public CategoryRepository(ShopContext context) : base(context)
        {
        }


        public async Task<bool> DeleteCategory(long categoryId)
        {
            var category = await Context.categories
                .Include(c => c.Childs)
                .ThenInclude(c => c.Childs).FirstOrDefaultAsync(f => f.Id == categoryId);

            if (category == null)
                return false;
            var isExistProduct = await Context.products
                .AnyAsync(f => f.CategoryId == categoryId ||
                f.SubCategoryId == categoryId ||
                f.SecondrySubCategoryId == categoryId);

            if (isExistProduct) return false;

            if (category.Childs.Any(c => c.Childs.Any()))
            {
                Context.RemoveRange(category.Childs.SelectMany(s => s.Childs));
            }
            Context.RemoveRange(category.Childs);
            Context.RemoveRange(category);
            return true;
        }
    }
}
