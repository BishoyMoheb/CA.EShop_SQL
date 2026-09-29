using CA.EShop_SQL.Application.IDatabase;
using CA.EShop_SQL.Domain.IRepositories;
using CA.EShop_SQL.Domain.Products;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CA.EShop_SQL.Application.ProductsOperations.ProductUpdating
{
    internal sealed class UProdCmdHandler : IRequestHandler<RUpdateProdCmd>
    {
        private readonly IRep_Product _rep_ProductI;
        private readonly IUnitOfWork _unitOfWorkI;

        public UProdCmdHandler(IRep_Product Rep_ProductI, IUnitOfWork UnitOfWorkI)
        {
            _rep_ProductI = Rep_ProductI;
            _unitOfWorkI = UnitOfWorkI;
        }

        public async Task Handle(RUpdateProdCmd rUPCmd_Request, CancellationToken cancellationToken)
        {
            var productToUpdate = await _rep_ProductI.GetByIdAsync(rUPCmd_Request.P_Id);
            if (productToUpdate is null)
            {
                throw new ProductNotFoundException(rUPCmd_Request.P_Id);
            }
            productToUpdate.Update(
                rUPCmd_Request.Name,
                new RMoney(rUPCmd_Request.Currency, rUPCmd_Request.Amount),
                R_Sku.Create(rUPCmd_Request.Sku)!);
            _rep_ProductI.Update(productToUpdate);
            await _unitOfWorkI.SaveChangesAsync(cancellationToken);
        }
    }
}
