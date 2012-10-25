namespace Miscellaneous.SemanticStrings.ProductSearch
{
    public class Product
    {
        public Product(ProductCode productCode, SupplierCode supplierCode, decimal price, CurrencyCode currencyCode)
        {
            ProductCode = productCode;
            SupplierCode = supplierCode;
            Price = price;
            CurrencyCode = currencyCode;
        }

        public ProductCode ProductCode { get; private set; }
        public SupplierCode SupplierCode { get; private set; }
        public decimal Price { get; private set; }
        public CurrencyCode CurrencyCode { get; private set; }
    }
}