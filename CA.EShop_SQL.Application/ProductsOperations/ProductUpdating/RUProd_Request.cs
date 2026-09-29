namespace CA.EShop_SQL.Application.ProductsOperations.ProductUpdating
{
    public record RUProd_Request(
                                string rUP_Name,
                                string rUP_Sku,
                                string rUP_Currency,
                                decimal rUP_Amount)
    {
        public readonly string Currency;
    }
}
