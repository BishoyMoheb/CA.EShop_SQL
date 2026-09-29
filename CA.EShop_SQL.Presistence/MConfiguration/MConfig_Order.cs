using CA.EShop_SQL.Domain.Customers;
using CA.EShop_SQL.Domain.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CA.EShop_SQL.Presistence.MConfiguration
{
    internal class MConfig_Order : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> ETBuilder_Order)
        {
            ETBuilder_Order.HasKey(o => o.O_Id);

            ETBuilder_Order.Property(o => o.O_Id)
                           .HasConversion( 
                                order => order.O_ID_Value,
                                value => new ROrderID(value));

            ETBuilder_Order.HasOne<Customer>()
                           .WithMany()
                           .HasForeignKey(o => o.C_Id)
                           .IsRequired();

            ETBuilder_Order.HasMany(o => o.ROL_I_LineItems)
                           .WithOne() 
                           .HasForeignKey(li => li.OrderId);
        }
    }
}
