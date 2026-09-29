using CA.EShop_SQL.Domain.Orders;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.EShop_SQL.Application.OrdersOperations.LineItemRemoval
{
    public record RLineItemCmdRemoval(ROrderID O_Id, RLItemID LI_Id) : IRequest;
}
