using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.EShop_SQL.Application.ProductsOperations.ProductSelection
{
    public record RProdResponse(
                                Guid rP_Id,
                                string rP_Name,
                                string rP_Sku,
                                string rP_Currency,
                                decimal rP_Amount);
}
