using System;
using NUnit.Framework;

namespace Miscellaneous.SemanticStrings.EmailAddress.Test
{
    /// <summary>
    /// </summary>
    [TestFixture]
    public class QaEmailAddress
    {
        [Test]
        public void WhenConstructWithBadInput_ExpectException()
        {
            try
            {
                var c = "BADSTRING".ToEmailAddress();
                Assert.Fail("Expected ArgumentException");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        [Test]
        public void WhenConstructWithBadInput_AndExplicitTransform_ExpectException()
        {
            try
            {
                // special validation
                var c = "bob@example.com".ToEmailAddress(s => s.Contains("bob") ? null : s);
                Assert.Fail("Expected ArgumentException");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }



        [Test]
        public void WhenConstructWithExplicitTransform_ExpectValid()
        {
            var c = "bob@example.com".ToEmailAddress(s => s.Substring(0, 3));
            Assert.AreEqual("bob", c.Value);
        }

        [Test]
        public void WhenConstructOptionWithBadInput_ExpectException()
        {
            var c = "BADSTRING".ToEmailAddressOption();
            Assert.IsNull(c);
        }


        [Test]
        public void WhenConstructWithGoodInput_ExpectNoException()
        {
            var c = "BOB@EXAMPLE.COM".ToEmailAddress();
            Assert.AreEqual("bob@example.com", c.ToString());
        }

        [Test]
        public void WhenConstructWithGoodInput_AndExplicitTransform_ExpectNoException()
        {
            // special validation
            var c = "BOB@example.com".ToEmailAddress(EmailAddress.TransformEmailAddress);
            Assert.AreEqual("bob@example.com", c.ToString());
        }

    }
}
