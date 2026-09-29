using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.EShop_SQL.Application.OrdersOperations.OrderSelection
{
    public record ROrderResponse(Guid ORes_ID, Guid C_Id, List<RLineItemResponse> L_LineItemsRes);
}
