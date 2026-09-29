using CA.EShop_SQL.Application.IDatabase;
using CA.EShop_SQL.Domain.IRepositories;
using CA.EShop_SQL.Domain.Products;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CA.EShop_SQL.Application.ProductsOperations.ProductDeleting
{
    internal sealed class DProdCmdHandler : IRequestHandler<RDeletingProdCmd>
    {
        private readonly IRep_Product _rep_ProductI;
        private readonly IUnitOfWork _unitOfWorkI;

        public DProdCmdHandler(IRep_Product Rep_ProductI, IUnitOfWork UnitOfWorkI)
        {
            _rep_ProductI = Rep_ProductI;
            _unitOfWorkI = UnitOfWorkI;
        }

        public async Task Handle(RDeletingProdCmd RDPCmd_Request, CancellationToken CToken)
        {
            var productToDelete = await _rep_ProductI.GetByIdAsync(RDPCmd_Request.rP_Id);
            if (productToDelete is null)
            {
                throw new ProductNotFoundException(RDPCmd_Request.rP_Id);
            }
            _rep_ProductI.Remove(productToDelete);
            await _unitOfWorkI.SaveChangesAsync(CToken);
        }
    }
}
