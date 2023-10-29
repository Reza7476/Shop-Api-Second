using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain
{
    public class AggregateRoot : BaseEntity
    {
        private readonly List<BaseDomainEvent> _domainEvents = new List<BaseDomainEvent>();

        [NotMapped]
        public List<BaseDomainEvent> DomainEvents => _domainEvents;

        public void AddDomainEvent(BaseDomainEvent eventItem)
        {
            _domainEvents.Add(eventItem);
        }

        public void RemoveDomainEvent(BaseDomainEvent eventItem)
        {
            _domainEvents?.Remove(eventItem);
        }
    }
}
