using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.EShop_SQL.Application.OrdersOperations.OrderSelection
{
    public record RLineItemResponse(Guid LItem_ID, decimal Price);
}
