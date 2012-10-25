using System.Linq;
using NUnit.Framework;

namespace Miscellaneous.FoldStates.ShoppingCart.Test
{
    /// <summary>
    /// Example using non-fold style -- requires constant downcasting to subclasses
    /// </summary>
    [TestFixture]
    public class QaShoppingCartNonFoldStyle
    {
        [Test]
        public void WhenEmptyCartAndAddItemExpectActiveCartWithOneItem()
        {
            // arrange
            var emptyCart = new CartStateEmpty();

            // act
            var newState = emptyCart.Add(Product.ProductX);

            // assert
            var activeState = newState as CartStateActive; //CAST!
            if (activeState != null)
            {
                var itemCount = activeState.Items.Count();
                Assert.That(itemCount, Is.EqualTo(1));
            }
            else
            {
                Assert.Fail("Expect ActiveState");
            }
        }

        [Test]
        public void WhenActiveCartWithOneItemAndAddItemExpectActiveCartWithTwoItems()
        {
            // arrange
            var activeCart1 = new CartStateActive(new[] { Product.ProductY });

            // act
            var newState = activeCart1.Add(Product.ProductX);

            // assert
            var activeState = newState as CartStateActive; //CAST!
            if (activeState != null)
            {
                var itemCount = activeState.Items.Count();
                Assert.That(itemCount, Is.EqualTo(2));
            }
            else
            {
                Assert.Fail("Expect CartStateActive");
            }
        }


        [Test]
        public void WhenActiveCartWithOneItemAndRemoveItemExpectEmptyCart()
        {
            // arrange
            var activeCart = new CartStateActive(new[] { Product.ProductY });

            // act
            var newState = activeCart.Remove(Product.ProductY);

            // assert
            var emptyState = newState as CartStateEmpty;    //CAST!
            if (emptyState == null)
            {
                Assert.Fail("Expect CartStateEmpty");
            }
        }


        [Test]
        public void WhenActiveCartWithTwoItemsAndPayExpectPaidCart()
        {
            var activeCart = new CartStateActive(new[] { Product.ProductX, Product.ProductY });

            const decimal paidAmount = 12.34m;
            var newState = activeCart.Pay(paidAmount);

            // assert
            var paidState = newState as CartStatePaid; //CAST!
            if (paidState != null)
            {
                var itemCount = paidState.Items.Count();
                Assert.That(itemCount, Is.EqualTo(2));

                var actualPaidAmount = paidState.Amount;
                Assert.That(actualPaidAmount, Is.EqualTo(paidAmount));
            }
            else
            {
                Assert.Fail("Expect CartStateActive");
            }

        }

        [Test]
        public void TransitionExample()
        {
            var currentState = new CartStateEmpty() as ICartState;

            //add some products from the UI, say
            currentState = TransitionAddProduct(currentState, Product.ProductX);
            currentState = TransitionAddProduct(currentState, Product.ProductY);

            //pay from the UI, say
            var cartStateActive = currentState as CartStateActive; //CAST!
            if (cartStateActive == null)
            {
                Assert.Fail("Expected CartStateActive here");
            }

            const decimal paidAmount = 12.34m;
            currentState = cartStateActive.Pay(paidAmount);

            var cartStatePaid = currentState as CartStatePaid; //CAST!
            if (cartStatePaid == null)
            {
                Assert.Fail("Expected CartStatePaid here");
            }

            var itemCount = cartStatePaid.Items.Count();
            Assert.That(itemCount, Is.EqualTo(2));

            var actualPaidAmount = cartStatePaid.Amount;
            Assert.That(actualPaidAmount, Is.EqualTo(paidAmount));

        }

        public ICartState TransitionAddProduct(ICartState currentState, Product product)
        {
            var cartStateEmpty = currentState as CartStateEmpty; //CAST!
            if (cartStateEmpty != null)
            {
                return cartStateEmpty.Add(Product.ProductY);
            }

            var cartStateActive = currentState as CartStateActive; //CAST!
            if (cartStateActive != null)
            {
                return cartStateActive.Add(Product.ProductY);
            }

            return currentState;
        }
    }
}
