using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain.Exceptions
{
    public  class InvalidDomainDataException:Exception
    {
        public InvalidDomainDataException()
        {
            
        }
        public InvalidDomainDataException(string message) : base(message) 
        {
            
        }
    }
}
