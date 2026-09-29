using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.EShop_SQL.Domain.Orders
{
    public record ROSummary(Guid ROSummaryId, Guid Cust_Id, decimal TotalPrice);
}
