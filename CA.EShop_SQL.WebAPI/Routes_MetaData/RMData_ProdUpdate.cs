using CA.EShop_SQL.Application.ProductsOperations.ProductUpdating;
using Carter.OpenApi;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CA.EShop_SQL.WebAPI.Routes_MetaData
{
    public class RMData_ProdUpdate : RouteMetaData
    {
        public override string Tag { get; } = "Products";

        public override string Description { get; } = "Updates an existing product.";

        public override string OperationId { get; } = "Products_Update";

        public override RouteMetaDataRequest[] Requests { get; } =
        {
            new RouteMetaDataRequest
            {
                Request = typeof(RUProd_Request)
            }
        };

        public override RouteMetaDataResponse[] Responses { get; } =
        {
            new RouteMetaDataResponse
            {
                Code = StatusCodes.Status200OK,
                Description = "Product updated successfully."
            },

            new RouteMetaDataResponse
            {
                Code = StatusCodes.Status400BadRequest,
                Description = "Invalid product updating request."
            },

            new RouteMetaDataResponse
            {
                Code = StatusCodes.Status404NotFound,
                Description = "Product was not found."
            }
        };
    }
}
