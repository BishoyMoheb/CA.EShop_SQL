using CA.EShop_SQL.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.EShop_SQL.Domain.IRepositories
{
    public interface IRep_Product
    {
        Task<Product?> GetByIdAsync(RProd_Id id);

        void Add(Product product);

        void Update(Product product);

        void Remove(Product product);
    }
}
