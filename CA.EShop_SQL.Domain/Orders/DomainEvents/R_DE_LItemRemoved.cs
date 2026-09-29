using CA.EShop_SQL.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.EShop_SQL.Domain.Orders.DomainEvents
{
    public record R_DE_LItemRemoved(Guid LIR_Id,
        ROrderID O_Id,
        RLItemID LI_Id) : R_DomainEvent(LIR_Id);
}
