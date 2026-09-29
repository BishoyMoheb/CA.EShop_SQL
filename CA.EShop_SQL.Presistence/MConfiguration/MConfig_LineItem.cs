using CA.EShop_SQL.Domain.Orders;
using CA.EShop_SQL.Domain.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.EShop_SQL.Presistence.MConfiguration
{
    internal class MConfig_LineItem : IEntityTypeConfiguration<LineItem>
    {
        public void Configure(EntityTypeBuilder<LineItem> ETBuilder_LineItem)
        {
            ETBuilder_LineItem.HasKey(li => li.LI_Id);

            ETBuilder_LineItem.Property(li => li.LI_Id)
                              .HasConversion(lineItemId => lineItemId.LI_ID_Value,
                                             value => new RLItemID(value));

            ETBuilder_LineItem.HasOne<Product>()
                              .WithMany()
                              .HasForeignKey(li => li.ProdId);

            ETBuilder_LineItem.OwnsOne(li => li.Price);
        }
    }
}
