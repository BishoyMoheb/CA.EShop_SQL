using Carter.OpenApi;
using Microsoft.AspNetCore.Http;

namespace CA.EShop_SQL.WebAPI.Routes_MetaData
{
    public class RMData_ProdDeletion : RouteMetaData
    {
        public override string Tag { get; } = "Products";

        public override string Description { get; } = "Deletes a product by its unique identifier.";

        public override string OperationId { get; } = "Products_Delete";

        public override RouteMetaDataResponse[] Responses { get; } =
        {
            new RouteMetaDataResponse
            {
                Code = StatusCodes.Status200OK,
                Description = "Product deleted successfully."
            },
            new RouteMetaDataResponse
            {
                Code = StatusCodes.Status404NotFound,
                Description = "Product was not found."
            }
        };
    }
}
