using Carter.OpenApi;
using CA.EShop_SQL.Application.ProductsOperations.ProductCreation;
using Microsoft.AspNetCore.Http;

namespace CA.EShop_SQL.WebAPI.Routes_MetaData
{
    public class RMData_ProdCreation : RouteMetaData
    {
        public override string Tag { get; } = "Products";

        public override string Description { get; } = "Creates a new product.";

        public override string OperationId { get; } = "Products_Create";

        public override RouteMetaDataRequest[] Requests { get; } =
        {
            new RouteMetaDataRequest
            {
                Request = typeof(RProdCreateCmd)
            }
        };

        public override RouteMetaDataResponse[] Responses { get; } =
        {
            new RouteMetaDataResponse
            {
                Code = StatusCodes.Status200OK,
                Description = "Product created successfully."
            },
            new RouteMetaDataResponse
            {
                Code = StatusCodes.Status400BadRequest,
                Description = "Invalid product creation request."
            }
        };
    }
}
