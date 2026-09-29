using CA.EShop_SQL.Domain.Customers;
using CA.EShop_SQL.Domain.Orders;
using CA.EShop_SQL.Domain.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Threading;
using System.Threading.Tasks;

namespace CA.EShop_SQL.Application.IDatabase
{
    public interface ICA_AppDbContext
    {
        DbSet<Customer> DbS_Customers { get; set; }

        DbSet<Order> DbS_Orders { get; set; }

        DbSet<ROSummary> DbS_ROSummaries { get; set; }

        DbSet<Product> DbS_Products { get; set; }

        DatabaseFacade Database { get; }

        Task<int> SaveChangesAsync(CancellationToken CToken = default);
    }
}
