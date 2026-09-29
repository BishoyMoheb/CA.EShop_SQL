using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Carter;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using CA.EShop_SQL.WebAPI.Endpoints;
using CA.EShop_SQL.WebAPI.Existensions;
using CA.EShop_SQL.Presistence; //To use SerCollectionI.AddPersistence(...);
using CA.EShop_SQL.Application; //To use SerCollectionI.AddApplication();
using CA.EShop_SQL.Application.ProductsOperations.ProductCreation;
using AspNetCoreRateLimit;
using System;

namespace CA.EShop_SQL.WebAPI
{
    /* Minimal APIs 
     * Installing NuGet Package NSwag.AspNetCore
     * Use AddOpenApiDocument and UseOpenApi */
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }


        public static IHostBuilder CreateHostBuilder(string[] args)
            => Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webHBuilderI =>
                {
                    webHBuilderI.ConfigureServices((webHBContext, SerCollectionI) =>
                    {
                        SerCollectionI.AddRouting();

                        SerCollectionI.AddMvcCore().AddApiExplorer();

                        SerCollectionI.AddPersistence(webHBContext.Configuration);

                        SerCollectionI.AddApplication();

                        SerCollectionI.AddCarter(coptions =>
                        {
                            coptions.OpenApi.DocumentTitle = "CA EShop PostgreSQL API";
                        });

                        SerCollectionI.AddSwaggerGen(SGenOptions =>
                        {
                            SGenOptions.SwaggerDoc("v1", new OpenApiInfo
                            {
                                Title = "CA EShop PostgreSQL API",
                                Version = "v1"
                            });
                        });

                        SerCollectionI.AddMemoryCache();

                        SerCollectionI.Configure<IpRateLimitOptions>
                                        (webHBContext.Configuration.GetSection("IpRateLimiting"));

                        SerCollectionI.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();

                        SerCollectionI.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();

                        SerCollectionI.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();

                        SerCollectionI.AddSingleton<IProcessingStrategy, AsyncKeyLockProcessingStrategy>();
                    });

                    webHBuilderI.Configure((webHBContext, AppBuilderI) =>
                    {
                        if (webHBContext.HostingEnvironment.IsDevelopment())
                        {
                            AppBuilderI.UseDeveloperExceptionPage();

                            AppBuilderI.UseSwagger(SOptions =>
                            {
                                SOptions.RouteTemplate = "openapi/{documentName}";
                            });

                            AppBuilderI.UseSwaggerUI(SOptions =>
                            {
                                SOptions.SwaggerEndpoint("/openapi",
                                                         "CA EShop PostgreSQL API");
                                SOptions.RoutePrefix = "swagger";
                            });
                        }
                        
                        AppBuilderI.ApplyMigrations();

                        AppBuilderI.UseRouting();

                        AppBuilderI.UseIpRateLimiting();

                        AppBuilderI.UseEndpoints(endpointsRB_I =>
                        {
                            endpointsRB_I.MapCarter();
                        });
                    });
                });
    }
}
