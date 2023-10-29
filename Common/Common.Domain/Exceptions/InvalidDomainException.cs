using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain.Exceptions
{
    public class InvalidDomainException:Exception
    {
        public InvalidDomainException()
        {
                
        }
        public InvalidDomainException(string message):base(message) 
        {
                
        }
    }

   
}
