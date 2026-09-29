using CA.EShop_SQL.Domain.Orders;
using MediatR;
using System;

namespace CA.EShop_SQL.Application.OrdersOperations.OrderCreation
{
    public record RCreateOrderCmd(Guid Cst_Id,
                                  RCust_Data rc_data) : IRequest<Guid>;
}
