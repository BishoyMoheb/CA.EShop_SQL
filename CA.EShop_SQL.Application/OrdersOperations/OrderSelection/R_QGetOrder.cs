using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.EShop_SQL.Application.OrdersOperations.OrderSelection
{
    public record R_QGetOrder(Guid QGO_Id) : IRequest<ROrderResponse>;
}
