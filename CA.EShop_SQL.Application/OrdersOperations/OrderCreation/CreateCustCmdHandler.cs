using CA.EShop_SQL.Application.IDatabase;
using CA.EShop_SQL.Domain.Customers;
using CA.EShop_SQL.Domain.IRepositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CA.EShop_SQL.Application.OrdersOperations.OrderCreation
{
    internal sealed class CreateCustCmdHandler : IRequestHandler<RCreateCustCmd, Guid>
    {
        private readonly IRep_Customer _rep_CustomerI;
        private readonly IUnitOfWork _unitOfWorkI;

        public CreateCustCmdHandler(IRep_Customer Rep_CustomerI, IUnitOfWork UnitOfWorkI)
        {
            _rep_CustomerI = Rep_CustomerI;
            _unitOfWorkI = UnitOfWorkI;
        }

        public async Task<Guid> Handle(RCreateCustCmd rCCCmd_request, 
                                       CancellationToken CToken)
        {
            var customerToCreate = Customer.Create(rCCCmd_request.Cst_Id,
                                           rCCCmd_request.Email,
                                           rCCCmd_request.Name);
            _rep_CustomerI.Add(customerToCreate);
            await _unitOfWorkI.SaveChangesAsync(CToken);
            return customerToCreate.C_Id.C_ID_Value;
        }
    }
}
