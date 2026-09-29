using MediatR;
using System;

namespace CA.EShop_SQL.Domain.Primitives
{
    public record R_DomainEvent(Guid DE_Id) : INotification;
}
