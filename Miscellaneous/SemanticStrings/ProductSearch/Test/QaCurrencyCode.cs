using System;
using NUnit.Framework;

namespace Miscellaneous.SemanticStrings.ProductSearch.Test
{
    /// <summary>
    /// </summary>
    [TestFixture]
    public class QaCurrencyCode
    {
        [Test]
        public void WhenConstructWithBadInput_ExpectException()
        {
            try
            {
                var c = "".ToCurrencyCode();
                Assert.Fail("Expected ArgumentException");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        [Test]
        public void WhenConstructOptionWithBadInput_ExpectException()
        {
            var c = "".ToCurrencyCodeOption();
            Assert.IsNull(c);
        }


        [Test]
        public void WhenConstructWithGoodInput_ExpectNoException()
        {
            var c = "usd".ToCurrencyCode();
            Assert.AreEqual("USD", c.ToString());
        }

    }
}
