using CA.EShop_SQL.Domain.Orders;
using Carter.OpenApi;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CA.EShop_SQL.WebAPI.Routes_MetaData
{
    public class RMData_OrderCreation : RouteMetaData
    {
        public override string Tag { get; } = "Orders";

        public override string Description { get; } = "Creates a new customer order.";

        public override string OperationId { get; } = "Orders_Create";

        public override RouteMetaDataRequest[] Requests { get; } =
        {
            new RouteMetaDataRequest
            {
                Request = typeof(RCust_Data)
            }
        };

        public override RouteMetaDataResponse[] Responses { get; } =
        {
            new RouteMetaDataResponse
            {
                Code = StatusCodes.Status200OK,
                Description = "Order created successfully.",
            },
            new RouteMetaDataResponse
            {
                Code = StatusCodes.Status404NotFound,
                Description = "Invalid order creation request."
            }
        };
    }
}
