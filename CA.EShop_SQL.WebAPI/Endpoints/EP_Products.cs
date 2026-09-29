using CA.EShop_SQL.Application.ProductsOperations.ProductCreation;
using CA.EShop_SQL.Application.ProductsOperations.ProductDeleting;
using CA.EShop_SQL.Application.ProductsOperations.ProductSelection;
using CA.EShop_SQL.Application.ProductsOperations.ProductUpdating;
using CA.EShop_SQL.Domain.Products;
using CA.EShop_SQL.WebAPI.Routes_MetaData;
using Carter;
using Carter.Request;
using Carter.Response;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;

namespace CA.EShop_SQL.WebAPI.Endpoints
{
    /* The way for using CarterModule & RouteMetaData */
    public class EP_Products : CarterModule
    {
        private readonly ISender _senderI;

        public EP_Products(ISender senderI)
        {
            _senderI = senderI;

            // POST: /api/cproducts
            Post<RMData_ProdCreation>("/api/cproducts",
                async (HttpRequest HReq, HttpResponse HRes) =>
                {
                    var request = await HReq.ReadFromJsonAsync<RProdCreateCmd>();
                    if (request == null)
                    {
                        HRes.StatusCode = StatusCodes.Status400BadRequest;
                        await HRes.WriteAsync("Invalid request body.");
                        return;
                    }
                    await _senderI.Send(request);
                    HRes.StatusCode = StatusCodes.Status200OK;
                });

            // GET: /api/cproducts/{id}
            Get<RMData_ProdSelection>("/api/cproducts/{id:guid}",
                async (HttpRequest HReq, HttpResponse HRes) =>
                {
                    Guid IdValue = HReq.RouteValues.As<Guid>("id");
                    try
                    {
                        var query = new RQueryGetProduct(new RProd_Id(IdValue));
                        var ProductToGet = await _senderI.Send(query);
                        HRes.StatusCode = StatusCodes.Status200OK;
                        await HRes.AsJson(ProductToGet);
                    }
                    catch (ProductNotFoundException Ex_Prod)
                    {
                        HRes.StatusCode = StatusCodes.Status404NotFound;
                        await HRes.WriteAsync(Ex_Prod.Message);
                    }
                });

            // PUT: /api/cproducts/{id}
            Put<RMData_ProdUpdate>("/api/cproducts/{id:guid}",
                async (HttpRequest HReq, HttpResponse HRes) =>
                {
                    Guid IdValue = HReq.RouteValues.As<Guid>("id");
                    var request = await HReq.ReadFromJsonAsync<RUProd_Request>();
                    if (request == null)
                    {
                        HRes.StatusCode = StatusCodes.Status400BadRequest;
                        await HRes.WriteAsync("Invalid request body.");
                        return;
                    }
                    var command = new RUpdateProdCmd(
                                                     new RProd_Id(IdValue),
                                                     request.rUP_Name,
                                                     request.rUP_Sku,
                                                     request.rUP_Currency,
                                                     request.rUP_Amount);
                    await _senderI.Send(command);
                    HRes.StatusCode = StatusCodes.Status200OK;
                });

            // DELETE: /api/cproducts/{id}
            Delete<RMData_ProdDeletion>("/api/cproducts/{id:guid}",
                async (HttpRequest HReq, HttpResponse HRes) =>
                {
                    Guid IdValue = HReq.RouteValues.As<Guid>("id");
                    try
                    {
                        var command = new RDeletingProdCmd(new RProd_Id(IdValue));
                        await _senderI.Send(command);
                        HRes.StatusCode = StatusCodes.Status200OK;
                    }
                    catch (ProductNotFoundException Ex_Prod)
                    {
                        HRes.StatusCode = StatusCodes.Status404NotFound;
                        await HRes.WriteAsync(Ex_Prod.Message);
                    }
                });
        }
    }
}
