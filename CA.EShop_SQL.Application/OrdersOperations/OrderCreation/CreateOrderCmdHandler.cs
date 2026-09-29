using CA.EShop_SQL.Application.IDatabase;
using CA.EShop_SQL.Domain.Customers;
using CA.EShop_SQL.Domain.IRepositories;
using CA.EShop_SQL.Domain.Orders;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CA.EShop_SQL.Application.OrdersOperations.OrderCreation
{
    internal sealed class CreateOrderCmdHandler : IRequestHandler<RCreateOrderCmd, Guid>
    {
        private readonly IRep_Customer _rep_CustomerI;
        private readonly IRep_Order _rep_OrderI;
        private readonly IRep_OrderSummary _rep_OrderSummaryI;
        private readonly IUnitOfWork _unitOfWorkI;

        public CreateOrderCmdHandler(
            IRep_Customer Rep_CustomerI,
            IRep_Order Rep_OrderI,
            IRep_OrderSummary Rep_OrderSummaryI,
            IUnitOfWork UnitOfWorkI)
        {
            _rep_CustomerI = Rep_CustomerI;
            _rep_OrderI = Rep_OrderI;
            _rep_OrderSummaryI = Rep_OrderSummaryI;
            _unitOfWorkI = UnitOfWorkI;
        }

        public async Task<Guid> Handle(RCreateOrderCmd RCOCmd_Request, CancellationToken CToken)
        {
            var customerToGet = await _rep_CustomerI.GetByIdAsync(
                new RCstID(RCOCmd_Request.Cst_Id));
            if (customerToGet is null)
            {
                throw new InvalidOperationException(
                $"Customer '{RCOCmd_Request.Cst_Id}' does not exist.");
            }
            var orderToCreate = Order.Create(customerToGet.C_Id);
            _rep_OrderI.Add(orderToCreate);
            _rep_OrderSummaryI.Add(new ROSummary(orderToCreate.O_Id.O_ID_Value, 
                                                 customerToGet.C_Id.C_ID_Value, 0));
            await _unitOfWorkI.SaveChangesAsync(CToken);
            return orderToCreate.O_Id.O_ID_Value;
        }
    }
}
