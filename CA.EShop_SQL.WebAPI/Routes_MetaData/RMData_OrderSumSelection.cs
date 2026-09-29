using CA.EShop_SQL.Domain.Orders;
using Carter.OpenApi;
using Microsoft.AspNetCore.Http;

namespace CA.EShop_SQL.WebAPI.Routes_MetaData
{
    public class RMData_OrderSumSelection : RouteMetaData
    {
        public override string Tag { get; } = "Orders"; 

        public override string Description { get; } = "Gets the summary of an order.";
        
        public override string OperationId { get; } = "Orders_GetOrderSummary";

        public override RouteMetaDataResponse[] Responses { get; } =
        {
            new RouteMetaDataResponse
            {
                Code = StatusCodes.Status200OK,
                Description = "Order summary retrieved successfully.",
                Response = typeof(ROrderID)
            },
            new RouteMetaDataResponse
            {
                Code = StatusCodes.Status400BadRequest,
                Description = "The order ID is invalid."
            },
            new RouteMetaDataResponse
            {
                Code = StatusCodes.Status404NotFound,
                Description = "The order was not found."
            }
        };
    }
}
