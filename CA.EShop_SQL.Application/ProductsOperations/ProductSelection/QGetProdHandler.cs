using CA.EShop_SQL.Application.IDatabase;
using CA.EShop_SQL.Domain.Products;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CA.EShop_SQL.Application.ProductsOperations.ProductSelection
{
    internal sealed class QGetProdHandler : IRequestHandler<RQueryGetProduct, RProdResponse>
    {
        private readonly ICA_AppDbContext _appContext;

        public QGetProdHandler(ICA_AppDbContext appContext)
        {
            _appContext = appContext;
        }

        public async Task<RProdResponse> Handle(RQueryGetProduct rRQGP_Request, CancellationToken CToken)
        {
            var product = await _appContext
                .DbS_Products
                .Where(p => p.Id == rRQGP_Request.P_Id)
                .Select(p => new RProdResponse(
                    p.Id.RP_Id_Value,
                    p.Name,
                    p.Sku.Value,
                    p.Price.Currency,
                    p.Price.Amount))
                .FirstOrDefaultAsync(CToken);
            if (product is null)
            {
                throw new ProductNotFoundException(rRQGP_Request.P_Id);
            }
            return product;
        }
    }
}
