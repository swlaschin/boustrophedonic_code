using System;
using NUnit.Framework;

namespace Miscellaneous.SemanticStrings.Example.Test
{
    public class QaWrappedString
    {
        [TestFixture]
        public class WrappedStringTrim_Construction
        {
            [Test]
            public void WhenConstructWithNull_ExpectException()
            {
                try
                {
                    var c = WrappedStringTrim.New(null);
                    Assert.Fail("Expected ArgumentException");
                }
                catch (ArgumentException)
                {

                }
            }

            [Test]
            public void WhenConstructWithAbc_ExpectValueIsAbc()
            {
                var c = WrappedStringTrim.New("abc");
                Assert.AreEqual("abc", c.Value);
            }

            [Test]
            public void WhenConstructWithAbcAndSpaces_ExpectValueIsAbc()
            {
                var c = WrappedStringTrim.New("   abc   ");
                Assert.AreEqual("abc", c.Value);
            }


            [Test]
            public void WhenConstructWithAbc_ExpectToStringIsAbc()
            {
                var c = WrappedStringTrim.New("abc");
                Assert.AreEqual("abc", c.ToString());
            }

            [Test]
            public void ExpectComparision()
            {
                var a = WrappedStringTrim.New("a");
                var b = WrappedStringTrim.New("b");

                Assert.AreEqual(-1, a.CompareTo(b));
                Assert.AreEqual(1, b.CompareTo(a));
                Assert.AreEqual(0, a.CompareTo(a));
            }

        }

        [TestFixture]
        public class WrappedStringTrimOption_Construction
        {
            [Test]
            public void WhenConstructWithNull_ExpectNull()
            {
                var c = WrappedStringTrim.NewOption(null);
                Assert.IsNull(c);
            }

            [Test]
            public void WhenConstructWithAbc_ExpectValueIsAbc()
            {
                var c = WrappedStringTrim.NewOption("abc");
                Assert.IsTrue(c.HasValue);
                Assert.AreEqual("abc", c.Value.Value);
            }

        }

        [TestFixture]
        public class WrappedStringToUpper_Construction
        {
            [Test]
            public void WhenConstructWithNull_ExpectException()
            {
                try
                {
                    var c = WrappedStringTrimToUpper.New(null);
                    Assert.Fail("Expected ArgumentException");
                }
                catch (ArgumentException)
                {

                }
            }

            [Test]
            public void WhenConstructWithAbc_ExpectValueIsAbc()
            {
                var c = WrappedStringTrimToUpper.New("abc");
                Assert.AreEqual("ABC", c.Value);
            }

            [Test]
            public void WhenConstructWithAbcAndSpaces_ExpectValueIsAbc()
            {
                var c = WrappedStringTrimToUpper.New("   abc   ");
                Assert.AreEqual("ABC", c.Value);
            }

        }

        [TestFixture]
        public class WrappedStringCustomTransformConstruction
        {
            [Test]
            public void WhenConstructCustomWithBadInput_ExpectException()
            {
                try
                {
                    var c = WrappedStringCustomTransform.New("BADSTRING");
                    Assert.Fail("Expected ArgumentException");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            [Test]
            public void WhenConstructCustomWithGoodInput_ExpectNoException()
            {
                var c = WrappedStringCustomTransform.New("custom123");
                Assert.AreEqual("CUSTOM123", c.ToString());
            }
        }

        [TestFixture]
        public class WhenTypesAreEqual
        {
            private readonly WrappedStringTrim _abc1 = "abc".ToWrappedStringTrim();
            private readonly WrappedStringTrim _abc2 = "abc".ToWrappedStringTrim();
            private readonly WrappedStringTrim _xyz = "xyz".ToWrappedStringTrim();

            [Test]
            public void WhenContentsAreEqual_ExpectEqualityUsingEqualsMethod()
            {
                var b = _abc1.Equals(_abc2);
                Assert.IsTrue(b);
            }

            [Test]
            public void WhenContentsAreEqual_ExpectHashContentEquality()
            {
                var b = _abc1.GetHashCode() == _abc2.GetHashCode();
                Assert.IsTrue(b);
            }

            [Test]
            public void WhenContentsAreEqual_ExpectEqualityUsingEqualsSymbol()
            {
                var b = _abc1 == _abc2;
                Assert.IsTrue(b);
            }

            [Test]
            public void WhenContentsAreEqual_ExpectInequalityFailsUsingEqualsSymbol()
            {
                var b = _abc1 != _abc2;
                Assert.IsFalse(b);
            }

            [Test]
            public void WhenContentsAreNotEqual_ExpectEqualityFailsUsingEqualsSymbol()
            {
                var b = _abc1 == _xyz;
                Assert.IsFalse(b);
            }

            [Test]
            public void WhenContentsAreNotEqual_ExpectInequalitySucceedsUsingEqualsSymbol()
            {
                var b = _abc1 != _xyz;
                Assert.IsTrue(b);
            }
        }

        [TestFixture]
        public class WhenTypesAreNotEqual
        {
            private readonly WrappedStringTrim _abc1 = WrappedStringTrim.New("abc");
            private readonly WrappedStringTrimToUpper _abc2 = WrappedStringTrimToUpper.New("abc");

            [Test]
            public void WhenContentsAreEqual_ExpectInequalityUsingEqualsMethod()
            {
                var b = _abc1.Equals(_abc2);
                Assert.IsFalse(b);
            }

            //symbol equality not allowed

            //[Test]
            //public void WhenContentsAreEqual_ExpectInequalityUsingEqualsSymbol()
            //{
            //    var b = _abc1 == _abc2;
            //    Assert.IsTrue(b);
            //}


        }

    }
}

