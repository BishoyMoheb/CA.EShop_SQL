using CA.EShop_SQL.Application.IDatabase;
using CA.EShop_SQL.Domain.Orders;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CA.EShop_SQL.Application.OrdersOperations.OrderSummarySelection
{
    internal sealed class QGetOSummary_Handler : IRequestHandler<R_QGetOrderSummary, ROSummary?>
    {
        private readonly ICA_AppDbContext _appDbContext;

        public QGetOSummary_Handler(ICA_AppDbContext AppDbContext)
        {
            _appDbContext = AppDbContext;
        }

        public async Task<ROSummary?> Handle(R_QGetOrderSummary QGOSum_Request, CancellationToken CToken)
        {
            return await _appDbContext.DbS_ROSummaries
                .AsNoTracking()
                .FirstOrDefaultAsync(o => o.ROSummaryId == QGOSum_Request.QGOSum_ID, CToken);
        }
    }
}
