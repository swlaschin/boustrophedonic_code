namespace Miscellaneous.FoldStates.ShoppingCart
{
    public class Product
    {
        public static Product ProductX = new Product("PRODUCTX");
        public static Product ProductY = new Product("PRODUCTY");

        public Product(string productCode)
        {
            ProductCode = productCode;
        }

        public string ProductCode { get; private set; }
    }
}