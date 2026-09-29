using CA.EShop_SQL.Domain.Products;
using Carter.OpenApi;
using Microsoft.AspNetCore.Http;

namespace CA.EShop_SQL.WebAPI.Routes_MetaData
{
    public class RMData_ProdSelection : RouteMetaData
    {
        public override string Tag { get; } = "Products";

        public override string Description { get; } = "Gets a product by its unique identifier.";

        public override string OperationId { get; } = "Products_GetById";

        public override RouteMetaDataResponse[] Responses { get; } =
        {
            new RouteMetaDataResponse
            {
                Code = StatusCodes.Status200OK,
                Description = "Product returned successfully.",
                Response = typeof(RProd_Id)
            },
            new RouteMetaDataResponse
            {
                Code = StatusCodes.Status404NotFound,
                Description = "Product was not found."
            }
        };
    }
}
