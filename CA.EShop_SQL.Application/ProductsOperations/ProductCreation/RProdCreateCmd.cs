using MediatR;

namespace CA.EShop_SQL.Application.ProductsOperations.ProductCreation
{
    public record RProdCreateCmd(string PName,
                                 string PSku,
                                 string PCurrency,
                                 decimal PAmount) : IRequest;
}
