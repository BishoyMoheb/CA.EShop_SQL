using CA.EShop_SQL.Domain.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.EShop_SQL.Domain.IRepositories
{
    public interface IRep_Customer
    {
        Task<Customer?> GetByIdAsync(RCstID id);

        void Add(Customer customerToAdd);
    }
}
