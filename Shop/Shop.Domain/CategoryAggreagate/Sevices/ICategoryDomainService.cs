using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.CategoryAggreagate.Sevices
{
    public interface ICategoryDomainService
    {

        bool SlugIsExist(string slug);
    }
}
