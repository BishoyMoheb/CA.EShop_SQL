using MediatR;
using System;

namespace CA.EShop_SQL.Application.OrdersOperations.OrderCreation
{
    public record RCreateCustCmd(Guid Cst_Id, 
                                 string Name, 
                                 string Email) : IRequest<Guid>;
}
