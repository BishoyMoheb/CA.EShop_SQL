using CA.EShop_SQL.Application.IDatabase;
using CA.EShop_SQL.Domain.IRepositories;
using CA.EShop_SQL.Domain.Products;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CA.EShop_SQL.Application.ProductsOperations.ProductCreation
{
    internal class ProdCCmdHandler : IRequestHandler<RProdCreateCmd>
    {
        private readonly IRep_Product _rep_ProductI;
        private readonly IUnitOfWork _unitOfWorkI;

        public ProdCCmdHandler(IRep_Product Rep_ProductI, IUnitOfWork UnitOfWorkI)
        {
            _rep_ProductI = Rep_ProductI;
            _unitOfWorkI = UnitOfWorkI;
        }

        public async Task Handle(RProdCreateCmd RPCCmd_Request, CancellationToken CToken)
        {
            var productToGet = new Product(
                                    new RProd_Id(Guid.NewGuid()),
                                    RPCCmd_Request.PName,
                                    new RMoney(RPCCmd_Request.PCurrency, RPCCmd_Request.PAmount),
                                    R_Sku.Create(RPCCmd_Request.PSku)!);

            _rep_ProductI.Add(productToGet);

            await _unitOfWorkI.SaveChangesAsync(CToken);
        }
    }
}
