using System.Linq;
using NUnit.Framework;

namespace Miscellaneous.SemanticStrings.ProductSearch.Test
{
    /// <summary>
    /// </summary>
    [TestFixture]
    public class QaProductRepository
    {
        [Test]
        public void WhenFindMatchingProductsExpectNullProductAccepted()
        {
            var newRepo = new ProductRepository();

            var matchingProductCodes = newRepo.FindMatchingProducts(null, null, ReferenceData.Gbp).Select(p => p.ProductCode);

            var expectedProductCodes = new[] { ReferenceData.ProductCodeX, ReferenceData.ProductCodeZ };
            Assert.That(matchingProductCodes, Is.EquivalentTo(expectedProductCodes));
        }

        [Test]
        public void WhenFindMatchingProductsExpectSpecificProductMatched()
        {
            var newRepo = new ProductRepository();

            var matchingProductCodes = newRepo.FindMatchingProducts(ReferenceData.ProductCodeX, null, ReferenceData.Gbp).Select(p => p.ProductCode);

            var expectedProductCodes = new[] { ReferenceData.ProductCodeX };
            Assert.That(matchingProductCodes, Is.EquivalentTo(expectedProductCodes));
        }
    }
}
