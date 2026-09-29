using CA.EShop_SQL.Domain.Orders;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.EShop_SQL.Application.OrdersOperations.OrderSummarySelection
{
    public record R_QGetOrderSummary(Guid QGOSum_ID) : IRequest<ROSummary?>;
}
