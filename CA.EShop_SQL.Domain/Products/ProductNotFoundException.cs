using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.EShop_SQL.Domain.Products
{
    public sealed class ProductNotFoundException : Exception
    {
        public ProductNotFoundException(RProd_Id rP_id)
            : base($"The product with the ID = {rP_id.RP_Id_Value} was not found")
        {
        }
    }
}
