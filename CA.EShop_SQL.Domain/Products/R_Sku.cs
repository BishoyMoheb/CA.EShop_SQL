using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.EShop_SQL.Domain.Products
{
    public record R_Sku
    {
        private const int DefaultLength = 8;

        private R_Sku(string value) => Value = value;

        public string Value { get; init; }

        public static R_Sku? Create(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }
            if (value.Length != DefaultLength)
            {
                return null;
            }
            return new R_Sku(value);
        }
    }
}
