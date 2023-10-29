using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain.Exceptions
{
    public class NullOrEmptyDomainDataException:Exception
    {
        public NullOrEmptyDomainDataException()
        {
                
        }
        public NullOrEmptyDomainDataException(string message):base(message) 
        {
                
        }




        public static void CheckString(string value,string nameofField)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new NullOrEmptyDomainDataException($"{nameofField}");
            }
        }
    }
}
