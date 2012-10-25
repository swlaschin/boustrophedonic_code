using System;
using NUnit.Framework;

namespace Miscellaneous.SemanticStrings.ProductSearch.Test
{
    /// <summary>
    /// </summary>
    [TestFixture]
    public class QaProductCode
    {
        [Test]
        public void WhenConstructWithBadInput_ExpectException()
        {
            try
            {
                var c = "BADSTRING".ToProductCode();
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
            var c = "BADSTRING".ToProductCodeOption();
            Assert.IsNull(c);
        }


        [Test]
        public void WhenConstructWithGoodInput_ExpectNoException()
        {
            var c = "product123".ToProductCode();
            Assert.AreEqual("PRODUCT123", c.ToString());
        }
    }
}
