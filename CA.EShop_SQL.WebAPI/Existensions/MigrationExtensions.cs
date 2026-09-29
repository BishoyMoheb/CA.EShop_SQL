using System;
using CA.EShop_SQL.Presistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CA.EShop_SQL.WebAPI.Existensions
{
    public static class MigrationExtensions
    {
        public static void ApplyMigrations(this IApplicationBuilder AppBuilderI)
        {
            using var serScopeI = AppBuilderI.ApplicationServices.CreateScope();

            var appDbContext = serScopeI.ServiceProvider.GetRequiredService<CA_AppDbContext>();

            appDbContext.Database.Migrate();
        }
    }
}
