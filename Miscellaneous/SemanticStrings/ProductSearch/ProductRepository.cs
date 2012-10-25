using System.Collections.Generic;
using System.Linq;

namespace Miscellaneous.SemanticStrings.ProductSearch
{
    internal class ProductRepository : IProductRepository
    {
        private readonly Product[] _allProducts = new[] 
        {
            new Product(ReferenceData.ProductCodeX, ReferenceData.SupplierCodeA,1.23m, ReferenceData.Usd),
            new Product(ReferenceData.ProductCodeX, ReferenceData.SupplierCodeB,2.34m, ReferenceData.Gbp),
            new Product(ReferenceData.ProductCodeY, ReferenceData.SupplierCodeA,3.45m, ReferenceData.Usd),
            new Product(ReferenceData.ProductCodeZ, ReferenceData.SupplierCodeC,4.56m, ReferenceData.Gbp)
        };


        /// <summary>
        /// Find exact match. Note that productCode is not allowed to be null.
        /// </summary>
        public Product GetByCode(ProductCode productCode)
        {
            return _allProducts.FirstOrDefault(p => p.ProductCode == productCode);
        }

        /// <summary>
        /// Find all matching. Note that productCode and supplierCode are optional but currencyCode is not.
        /// </summary>
        public IEnumerable<Product> FindMatchingProducts(ProductCode? productCode, SupplierCode? supplierCode,
                                                         CurrencyCode currencyCode)
        {
            return _allProducts
                .Where(p =>
                    (!productCode.HasValue || p.ProductCode == productCode.Value)
                    && (!supplierCode.HasValue || p.SupplierCode == supplierCode.Value)
                    && (p.CurrencyCode == currencyCode)
                );
        }
    }
}
