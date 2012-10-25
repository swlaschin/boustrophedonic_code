namespace Miscellaneous.FoldStates.ShoppingCart
{
    public partial class CartStateEmpty 
    {
        internal CartStateEmpty()
        {
        }

        public ICartState Add(Product item)
        {
            var newItems = new[] { item };
            var newState = new CartStateActive(newItems);
            return newState;
        }

    }
}
