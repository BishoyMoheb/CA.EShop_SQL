using CA.EShop_SQL.Domain.Products;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.EShop_SQL.Application.ProductsOperations.ProductDeleting
{
    public record RDeletingProdCmd(RProd_Id rP_Id) : IRequest;
}
