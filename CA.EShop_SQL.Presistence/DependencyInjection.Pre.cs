using CA.EShop_SQL.Application.IDatabase;
using CA.EShop_SQL.Domain.IRepositories;
using CA.EShop_SQL.Presistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CA.EShop_SQL.Presistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(
            this IServiceCollection SerCollectionI,
            IConfiguration ConfigI)
        {
            SerCollectionI.AddDbContext<CA_AppDbContext>(DbCOBuilder =>
                DbCOBuilder
                    .UseNpgsql(ConfigI.GetConnectionString("DBConn_CA_SQL"))
                    //.UseSnakeCaseNamingConvention()
                    );

            SerCollectionI.AddScoped<ICA_AppDbContext>(serProviderI =>
                serProviderI.GetRequiredService<CA_AppDbContext>());

            SerCollectionI.AddScoped<IUnitOfWork>(sp =>
                sp.GetRequiredService<CA_AppDbContext>());

            SerCollectionI.AddScoped<IRep_Customer, RepCustomer>();

            SerCollectionI.AddScoped<IRep_Order, RepOrder>();

            SerCollectionI.AddScoped<IRep_OrderSummary, RepOrderSummaries>();

            SerCollectionI.AddScoped<IRep_Product, RepProduct>();

            return SerCollectionI;
        }
    }
}
