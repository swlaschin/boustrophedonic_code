using System.Collections.Generic;

namespace Miscellaneous.SemanticStrings.ProductSearch
{
    interface IProductRepository
    {
        Product GetByCode(ProductCode productCode);

        /// <summary>
        /// Find all matching. Note that productCode and supplierCode are optional but currencyCode is not.
        /// </summary>
        IEnumerable<Product> FindMatchingProducts(ProductCode? productCode, SupplierCode? supplierCode, CurrencyCode currencyCode);
    }
}
