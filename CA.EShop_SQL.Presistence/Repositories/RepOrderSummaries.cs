using CA.EShop_SQL.Domain.IRepositories;
using CA.EShop_SQL.Domain.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.EShop_SQL.Presistence.Repositories
{
    internal sealed class RepOrderSummaries : IRep_OrderSummary
    {
        private readonly CA_AppDbContext _appContext;

        public RepOrderSummaries(CA_AppDbContext AppContext)
        {
            _appContext = AppContext;
        }

        public void Add(ROSummary orderSummaryToAdd)
        {
            _appContext.DbS_ROSummaries.Add(orderSummaryToAdd);
        }
    }
}
