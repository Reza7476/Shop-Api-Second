using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain
{
    public class BaseDomainEvent:INotification

    {
        public DateTime CreationDate { get; protected set; }

        public BaseDomainEvent()
        {
            CreationDate = DateTime.Now;
        }
    }
}
