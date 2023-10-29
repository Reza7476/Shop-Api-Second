using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain.Exceptions
{
    public class SlugIsDublicatedException:BaseDomainException
    {
        public SlugIsDublicatedException():base ("slug is dublicated")
        {
            
        }
        public SlugIsDublicatedException(string message):base(message)
        {
            
        }
    }
}
