using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;
using System.IO;

namespace CA.EShop_SQL.Presistence
{
    public class DesignTimeDbCF : IDesignTimeDbContextFactory<CA_AppDbContext>
    {
        public CA_AppDbContext CreateDbContext(string[] args)
        {
            if (!Debugger.IsAttached)
            {
                Debugger.Launch();
            }
            var basePath = Path.Combine(Directory.GetCurrentDirectory(),
                                        @"..\CA.EShop_SQL.WebAPI");
            IConfigurationRoot configRoot_I = new ConfigurationBuilder()
                    .SetBasePath(basePath)
                    .AddJsonFile("appsettings.json")
                    .Build();
            var ConnString = configRoot_I.GetConnectionString("DBConn_CA_SQL");
            var DbCOBuilder = new DbContextOptionsBuilder<CA_AppDbContext>();
            DbCOBuilder.UseNpgsql(ConnString);
            var ca_AppDbContext = new CA_AppDbContext(DbCOBuilder.Options, null);
            return ca_AppDbContext;
        }
    }
}
