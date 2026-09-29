using CA.EShop_SQL.Domain.Orders.DomainEvents;
using CA.EShop_SQL.IntegrationEvents;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CA.EShop_SQL.Application.OrdersOperations.OrderCreation
{
    internal sealed class DE_OrderCreated_Handler : INotificationHandler<R_DE_OrderCreated>
    {
        public Task Handle(R_DE_OrderCreated RDE_OC_Notification, CancellationToken CToken)
        {
            new R_IE_OrderCreated(RDE_OC_Notification.OrderId.O_ID_Value);
            return Task.CompletedTask;
        }
    }
}
