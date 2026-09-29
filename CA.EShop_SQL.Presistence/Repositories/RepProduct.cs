using CA.EShop_SQL.Domain.IRepositories;
using CA.EShop_SQL.Domain.Products;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.EShop_SQL.Presistence.Repositories
{
    internal sealed class RepProduct : IRep_Product
    {
        private readonly CA_AppDbContext _appContext;

        public RepProduct(CA_AppDbContext AppContext)
        {
            _appContext = AppContext;
        }

        public void Add(Product product)
        {
            _appContext.DbS_Products.Add(product);
        }

        public Task<Product> GetByIdAsync(RProd_Id id)
        {
            return _appContext.DbS_Products.SingleOrDefaultAsync(p => p.Id == id);
        }

        public void Remove(Product product)
        {
            _appContext.DbS_Products.Remove(product);
        }

        public void Update(Product product)
        {
            _appContext.DbS_Products.Update(product);
        }
    }
}
