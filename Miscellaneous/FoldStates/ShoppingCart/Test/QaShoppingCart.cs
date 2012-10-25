using System.Linq;
using NUnit.Framework;

namespace Miscellaneous.FoldStates.ShoppingCart.Test
{
    /// <summary>
    /// Empty cart case
    /// * You cannot remove an item from an empty cart
    /// * You cannot enumerate the items in an empty cart
    /// * You cannot pay for an empty cart
    /// * If you add a item to an empty cart you get an active cart with one item
    /// 
    /// Active cart case
    /// * If you remove an item from a cart with one item you get an empty cart
    /// * If you remove an item from a cart with two items you get an active cart with one item
    /// * If you add a item to an active cart with two items you get an active cart with three items
    /// * If you pay for an active cart you get an paid cart with the same number of items and the same amount paid
    /// 
    /// Paid cart case
    /// * You cannot remove an item from an paid cart
    /// * You can enumerate the items in an paid cart
    /// * You cannot pay for an paid cart again
    /// </summary>
    [TestFixture]
    public class QaShoppingCart
    {
        [Test]
        public void WhenEmptyCartAndAddItemExpectActiveCartWithOneItem()
        {
            var emptyCart = new CartStateEmpty();

            var newState = emptyCart.Add(Product.ProductX);

            var isActiveState = newState.Func(cartStateEmpty => false, cartStateActive => true, cartStatePaid => false);
            Assert.IsTrue(isActiveState);

            var itemCount = newState.Func(cartStateEmpty => -1, cartStateActive => cartStateActive.Items.Count(), cartStatePaid => -1);
            Assert.That(itemCount, Is.EqualTo(1));
        }

        [Test]
        public void WhenActiveCartWithOneItemAndAddItemExpectActiveCartWithTwoItems()
        {
            var activeCart1 = new CartStateActive(new[] { Product.ProductY });

            var newState = activeCart1.Add(Product.ProductX);

            var isActiveState = newState.Func(cartStateEmpty => false, cartStateActive => true, cartStatePaid => false);
            Assert.IsTrue(isActiveState);

            var itemCount = newState.Func(cartStateEmpty => -1, cartStateActive => cartStateActive.Items.Count(), cartStatePaid => -1);
            Assert.That(itemCount, Is.EqualTo(2));
        }


        [Test]
        public void WhenActiveCartWithOneItemAndRemoveItemExpectEmptyCart()
        {
            var activeCart = new CartStateActive(new[] { Product.ProductY });

            var newState = activeCart.Remove(Product.ProductY);

            var isEmptyState = newState.Func(cartStateEmpty => true, cartStateActive => false, cartStatePaid => false);
            Assert.IsTrue(isEmptyState);

        }

        [Test]
        public void WhenActiveCartWithTwoItemsAndRemoveItemExpectActiveCartWithOneItem()
        {
            var activeCart = new CartStateActive(new[] { Product.ProductX, Product.ProductY });

            var newState = activeCart.Remove(Product.ProductY);

            var isActiveState = newState.Func(cartStateEmpty => false, cartStateActive => true, cartStatePaid => false);
            Assert.IsTrue(isActiveState);

            var itemCount = newState.Func(cartStateEmpty => -1, cartStateActive => cartStateActive.Items.Count(), cartStatePaid => -1);
            Assert.That(itemCount, Is.EqualTo(1));

        }

        [Test]
        public void WhenActiveCartWithTwoItemsAndPayExpectPaidCart()
        {
            var activeCart = new CartStateActive(new[] { Product.ProductX, Product.ProductY });

            const decimal paidAmount = 12.34m;
            var newState = activeCart.Pay(paidAmount);

            var isPaidState = newState.Func(cartStateEmpty => false, cartStateActive => false, cartStatePaid => true);
            Assert.IsTrue(isPaidState);

            var itemCount = newState.Func(cartStateEmpty => -1, cartStateActive => -1, cartStatePaid => cartStatePaid.Items.Count());
            Assert.That(itemCount, Is.EqualTo(2));

            var actualPaidAmount = newState.Func(cartStateEmpty => -1, cartStateActive => -1, cartStatePaid => cartStatePaid.Amount);
            Assert.That(actualPaidAmount, Is.EqualTo(paidAmount));

        }

        [Test]
        public void TransitionExample()
        {
            var currentState = new CartStateEmpty() as ICartState;

            //add some products from the UI, say
            currentState = TransitionAddProduct(currentState, Product.ProductX);
            currentState = TransitionAddProduct(currentState, Product.ProductY);

            //pay from the UI, say
            const decimal paidAmount = 12.34m;
            currentState = currentState.Transition(
                cartStateEmpty => cartStateEmpty,
                cartStateActive => cartStateActive.Pay(paidAmount),
                cartStatePaid => cartStatePaid);

            var isPaidState = currentState.Func(cartStateEmpty => false, cartStateActive => false, cartStatePaid => true);
            Assert.IsTrue(isPaidState);

            var itemCount = currentState.Func(cartStateEmpty => -1, cartStateActive => -1, cartStatePaid => cartStatePaid.Items.Count());
            Assert.That(itemCount, Is.EqualTo(2));

            var actualPaidAmount = currentState.Func(cartStateEmpty => -1, cartStateActive => -1, cartStatePaid => cartStatePaid.Amount);
            Assert.That(actualPaidAmount, Is.EqualTo(paidAmount));

        }

        public ICartState TransitionAddProduct(ICartState currentState, Product product)
        {
            return currentState.Transition(
                cartStateEmpty => cartStateEmpty.Add(product),
                cartStateActive => cartStateActive.Add(product),
                cartStatePaid => cartStatePaid);

        }
    }
}
