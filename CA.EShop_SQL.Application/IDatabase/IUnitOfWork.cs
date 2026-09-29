using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CA.EShop_SQL.Application.IDatabase
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync(CancellationToken CToken = default);
    }
}
