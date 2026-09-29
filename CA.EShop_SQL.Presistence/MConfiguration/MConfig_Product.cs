using CA.EShop_SQL.Domain.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CA.EShop_SQL.Presistence.MConfiguration
{
    internal class MConfig_Product : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> ETBuilder_Product)
        {
            ETBuilder_Product.HasKey(p => p.Id);

            ETBuilder_Product.Property(p => p.Id)
                             .HasConversion(
                                    productId => productId.RP_Id_Value,
                                    value => new RProd_Id(value));

            ETBuilder_Product.Property(p => p.Sku)
                             .HasConversion(
                                    sku => sku.Value,
                                    value => R_Sku.Create(value)!);

            ETBuilder_Product.OwnsOne(p => p.Price, priceBuilder =>
            {
                priceBuilder.Property(m => m.Currency).HasMaxLength(3);
            });
        }
    }
}
