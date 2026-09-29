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

namespace CA.EShop_SQL.Application.OrdersOperations.OrderSelection
{
    internal sealed class QGetOrder_Handler : IRequestHandler<R_QGetOrder, ROrderResponse>
    {
        private readonly ICA_AppDbContext _appDbContext;

        public QGetOrder_Handler(ICA_AppDbContext AppDbContext)
        {
            _appDbContext = AppDbContext;
        }

        public async Task<ROrderResponse> Handle(R_QGetOrder rQGO_Request, CancellationToken CToken)
        {
            var orderResponse = await _appDbContext
                .DbS_Orders
                .Where(o => o.O_Id == new ROrderID(rQGO_Request.QGO_Id))
                .Select(o => new ROrderResponse(
                    o.O_Id.O_ID_Value,
                    o.C_Id.C_ID_Value,
                    o.ROL_I_LineItems
                        .Select(li => new RLineItemResponse(li.LI_Id.LI_ID_Value, li.Price.Amount))
                        .ToList()))
                .SingleAsync(CToken);

            return orderResponse;
        }
    }
}
