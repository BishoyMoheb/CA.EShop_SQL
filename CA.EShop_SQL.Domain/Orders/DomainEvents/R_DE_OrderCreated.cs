using CA.EShop_SQL.Domain.Primitives;
using System;

namespace CA.EShop_SQL.Domain.Orders.DomainEvents
{
    public record R_DE_OrderCreated(Guid Id, ROrderID OrderId) : R_DomainEvent(Id);
}
