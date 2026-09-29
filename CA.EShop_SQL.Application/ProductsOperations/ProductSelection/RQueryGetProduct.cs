using CA.EShop_SQL.Domain.Products;
using MediatR;

namespace CA.EShop_SQL.Application.ProductsOperations.ProductSelection
{
    public record RQueryGetProduct(RProd_Id P_Id) : IRequest<RProdResponse>;
}
