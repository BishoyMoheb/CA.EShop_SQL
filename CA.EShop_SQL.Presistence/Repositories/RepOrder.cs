using CA.EShop_SQL.Domain.IRepositories;
using CA.EShop_SQL.Domain.Orders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.EShop_SQL.Presistence.Repositories
{
    internal sealed class RepOrder : IRep_Order
    {
        private readonly CA_AppDbContext _appContext;

        public RepOrder(CA_AppDbContext AppContext)
        {
            _appContext = AppContext;
        }

        public Task<Order?> GetByIdWithLineItemAsync(ROrderID id, RLItemID lineItemId)
        {
            return _appContext.DbS_Orders
                .Include(o => o.ROL_I_LineItems.Where(li => li.LI_Id == lineItemId))
                .SingleOrDefaultAsync(o => o.O_Id == id);
        }

        public bool HasOneLineItem(Order orderToCheck)
        {
            return _appContext.DbS_LineItems.Count(li => li.OrderId == orderToCheck.O_Id) == 1;
        }

        public void Add(Order orderToAdd)
        {
            _appContext.DbS_Orders.Add(orderToAdd);
        }
    }
}
