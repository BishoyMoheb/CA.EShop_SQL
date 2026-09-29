using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.EShop_SQL.Domain.Customers
{
    public class Customer
    {
        public RCstID C_Id { get; private set; }

        public string Email { get; private set; } = string.Empty;

        public string Name { get; private set; } = string.Empty;

        private Customer()
        {
        }

        private Customer(RCstID cid, string email, string name)
        {
            C_Id = cid;
            Email = email;
            Name = name;
        }

        public static Customer Create(Guid Cst_id, string C_email, string C_name)
        {
            return new Customer(new RCstID(Cst_id), C_email.Trim(), C_name.Trim());
        }
    }
}
