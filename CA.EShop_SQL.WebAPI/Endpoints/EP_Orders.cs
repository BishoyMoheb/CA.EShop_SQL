using CA.EShop_SQL.Application.OrdersOperations.LineItemRemoval;
using CA.EShop_SQL.Application.OrdersOperations.OrderCreation;
using CA.EShop_SQL.Application.OrdersOperations.OrderSummarySelection;
using CA.EShop_SQL.Domain.Orders;
using CA.EShop_SQL.WebAPI.Routes_MetaData;
using Carter;
using Carter.Request;
using Carter.Response;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Net.Http.Json;

namespace CA.EShop_SQL.WebAPI.Endpoints
{
    /* The way for using CarterModule & RouteMetaData */
    public class EP_Orders : CarterModule
    {
        private readonly ISender _senderI;

        public EP_Orders(ISender senderI)
        {
            _senderI = senderI;

            // POST: /api/corders
            Post<RMData_OrderCreation>("/api/corders", 
                async (HttpRequest HReq, HttpResponse HRes) =>
                {
                    var CustomerToAdd = await HReq.ReadFromJsonAsync<RCust_Data>();
                    Guid Cust_ID = Guid.NewGuid();
                    var Cust_Cmd = new RCreateCustCmd(Cust_ID, CustomerToAdd.Name, CustomerToAdd.Email);
                    await _senderI.Send(Cust_Cmd);
                    var command = new RCreateOrderCmd(Cust_ID,
                                  new RCust_Data(CustomerToAdd.Name, CustomerToAdd.Email));
                    await _senderI.Send(command);
                    HRes.StatusCode = StatusCodes.Status200OK;
                });

            // DELETE: /api/corders/{id}/line-items/{lineItemId}
            Delete<RMData_OrderLItemRemoval>("/api/corders/{id}/line-items/{lineItemId}", 
                async (HttpRequest HReq, HttpResponse HRes) =>
                {
                    Guid OIdValue = HReq.RouteValues.As<Guid>("id");
                    Guid LItemIdValue= HReq.RouteValues.As<Guid>("lineItemId"); 
                    var command = new RLineItemCmdRemoval(new ROrderID(OIdValue), new RLItemID(LItemIdValue));
                    await _senderI.Send(command);
                    HRes.StatusCode = StatusCodes.Status200OK;
                });

            // GET: /api/corders/{id}/summary
            Get<RMData_OrderSumSelection>("/api/corders/{id}/summary",
                async (HttpRequest HReq, HttpResponse HRes) =>
                {
                    Guid QGOS_ID_Value = HReq.RouteValues.As<Guid>("id");
                    var query = new R_QGetOrderSummary(QGOS_ID_Value);
                    await _senderI.Send(query);
                    HRes.StatusCode = StatusCodes.Status200OK;
                });
        }
    }
}
