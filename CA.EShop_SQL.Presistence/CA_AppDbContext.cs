using CA.EShop_SQL.Application.IDatabase;
using CA.EShop_SQL.Domain.Customers;
using CA.EShop_SQL.Domain.Orders;
using CA.EShop_SQL.Domain.Primitives;
using CA.EShop_SQL.Domain.Products;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CA.EShop_SQL.Presistence
{
    public class CA_AppDbContext : DbContext, ICA_AppDbContext, IUnitOfWork
    {
        private readonly IPublisher _publisherI;

        public CA_AppDbContext(DbContextOptions DbCOptions, IPublisher PublisherI)
            : base(DbCOptions)
        {
            _publisherI = PublisherI;
        }

        protected override void OnModelCreating(ModelBuilder MBuilder)
        {
            MBuilder.ApplyConfigurationsFromAssembly(typeof(CA_AppDbContext).Assembly);
        }

        public DbSet<Customer> DbS_Customers { get; set; }

        public DbSet<Order> DbS_Orders { get; set; }

        public DbSet<ROSummary> DbS_ROSummaries { get; set; }

        public DbSet<Product> DbS_Products { get; set; }

        public DbSet<LineItem> DbS_LineItems { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken CToken = new CancellationToken())
        {
            var domainEvents = ChangeTracker.Entries<Entity>()
                .Select(e => e.Entity)
                .Where(e => e.Get_ColI_DomainEvents().Any())
                .SelectMany(e => e.Get_ColI_DomainEvents());
            var result = await base.SaveChangesAsync(CToken);
            foreach (var domainEvent in domainEvents)
            {
                await _publisherI.Publish(domainEvent, CToken);
            }
            return result;
        }
    }
}
