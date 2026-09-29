using CA.EShop_SQL.Domain.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.EShop_SQL.Presistence.MConfiguration
{
    internal class MConfig_Customer : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> ETBuilder_Customer)
        {
            ETBuilder_Customer.HasKey(c => c.C_Id);

            ETBuilder_Customer.Property(c => c.C_Id)
                              .HasConversion(custId => custId.C_ID_Value,
                                             value => new RCstID(value));

            ETBuilder_Customer.Property(c => c.Name).HasMaxLength(100);

            ETBuilder_Customer.Property(c => c.Email).HasMaxLength(255);

            ETBuilder_Customer.HasIndex(c => c.Email).IsUnique();
        }
    }
}
