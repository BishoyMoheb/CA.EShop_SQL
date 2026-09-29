using Carter.OpenApi;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CA.EShop_SQL.WebAPI.Routes_MetaData
{
    public class RMData_OrderLItemRemoval : RouteMetaData
    {
        public override string Tag { get; } = "Orders";

        public override string Description { get; } = "Removes a line item from an order.";

        public override string OperationId { get; } = "Orders_RemoveLineItem";

        public override RouteMetaDataResponse[] Responses { get; } =
        {
            new RouteMetaDataResponse
            { 
                Code = StatusCodes.Status200OK, 
                Description = "Order line item removed successfully." 
            }, 
            new RouteMetaDataResponse 
            { 
                Code = StatusCodes.Status400BadRequest, 
                Description = "The order ID or line-item ID is invalid." 
            }, 
            new RouteMetaDataResponse 
            { 
                Code = StatusCodes.Status404NotFound, 
                Description = "The order or line item was not found." 
            }
        };
    }
}
