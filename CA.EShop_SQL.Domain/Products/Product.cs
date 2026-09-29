using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.EShop_SQL.Domain.Products
{
    public class Product
    {
        public Product(RProd_Id pId, string pname, RMoney pprice, R_Sku rsku)
        {
            Id = pId;
            Name = pname;
            Price = pprice;
            Sku = rsku;
        }

        private Product()
        {
        }

        public RProd_Id Id { get; private set; }

        public string Name { get; private set; } = string.Empty;

        public RMoney Price { get; private set; }

        public R_Sku Sku { get; private set; }

        public void Update(string pname, RMoney pprice, R_Sku rsku)
        {
            Name = pname;
            Price = pprice;
            Sku = rsku;
        }
    }
}
