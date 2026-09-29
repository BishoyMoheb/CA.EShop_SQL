using CA.EShop_SQL.Domain.Products;
using MediatR;

namespace CA.EShop_SQL.Application.ProductsOperations.ProductUpdating
{
    public record RUpdateProdCmd(
                                RProd_Id P_Id,
                                string Name,
                                string Sku,
                                string Currency,
                                decimal Amount) : IRequest;
}
