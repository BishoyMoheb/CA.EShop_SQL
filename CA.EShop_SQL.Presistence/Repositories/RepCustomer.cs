using CA.EShop_SQL.Domain.Customers;
using CA.EShop_SQL.Domain.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.EShop_SQL.Presistence.Repositories
{
    internal sealed class RepCustomer : IRep_Customer
    {
        private readonly CA_AppDbContext _appContext;

        public RepCustomer(CA_AppDbContext appContext)
        {
            _appContext = appContext;
        }

        public Task<Customer?> GetByIdAsync(RCstID id)
        {
            return _appContext.DbS_Customers
                .SingleOrDefaultAsync(c => c.C_Id == id);
        }

        public void Add(Customer customerToAdd)
        {
            _appContext.DbS_Customers.Add(customerToAdd);
        }
    }
}
