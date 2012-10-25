using System.Collections.Generic;

namespace Miscellaneous.FoldStates.ShoppingCart
{
    public partial class CartStateActive
    {
        public CartStateActive(IEnumerable<Product> items)
        {
            Items = items;
        }

        public IEnumerable<Product> Items { get; private set; }

        public ICartState Add(Product item)
        {
            var newItems = new List<Product>(Items) { item };
            return new CartStateActive(newItems);
        }

        public ICartState Remove(Product item)
        {
            var newItems = new List<Product>(Items);
            newItems.Remove(item);
            return newItems.Count > 0
                ? (ICartState)new CartStateActive(newItems)
                : new CartStateEmpty();
        }

        public ICartState Pay(decimal amount)
        {
            return new CartStatePaid(Items, amount);
        }
    }
}
