using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.EShop_SQL.Domain.Primitives
{
    public abstract class Entity
    {
        private readonly List<R_DomainEvent> _l_domainEvents = new();

        public ICollection<R_DomainEvent> Get_ColI_DomainEvents() => _l_domainEvents;

        protected void Raise(R_DomainEvent domainEvent)
        {
            _l_domainEvents.Add(domainEvent);
        }
    }
}
