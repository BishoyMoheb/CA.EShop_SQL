using CA.EShop_SQL.Domain.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.EShop_SQL.Domain.IRepositories
{
    public interface IRep_Order
    {
        Task<Order?> GetByIdWithLineItemAsync(ROrderID id, RLItemID lineItemId);

        bool HasOneLineItem(Order orderToCheck);

        void Add(Order orderToAdd);
    }
}
