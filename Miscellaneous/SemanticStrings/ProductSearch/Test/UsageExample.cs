using System;
using NUnit.Framework;

namespace Miscellaneous.SemanticStrings.ProductSearch.Test
{
    /// <summary>
    /// </summary>
    [TestFixture]
    public class UsageExample
    {

        void BuySomething(ProductCode productCode, decimal price, CurrencyCode currencyCode)
        {
            if (productCode == null) { throw new ArgumentNullException("productCode"); }
            if (currencyCode == null) { throw new ArgumentNullException("currencyCode"); }

            Console.WriteLine("Bought {0} for {1}{2}", productCode, price, currencyCode);
        }

        void BuySomethingWithOptionalCurrency(ProductCode productCode, decimal price, CurrencyCode? currencyCode)
        {
            if (productCode == null) { throw new ArgumentNullException("productCode"); }
            currencyCode = currencyCode ?? "gbp".ToCurrencyCode();

            Console.WriteLine("Bought {0} for {1}{2}", productCode, price, currencyCode);
        }


        [Test]
        public void TestBuySomething()
        {
            var product1 = "product1".ToProductCode();
            var usd = "usd".ToCurrencyCode();
            BuySomething(product1, 12.34m, usd);

            // try with null product
            //BuySomething(null, 12.34m, usd);

            // try with product and currency swapped
            //BuySomething(usd, 12.34m, product1);

            BuySomethingWithOptionalCurrency(product1, 12.34m, null);
        }
    }
}
