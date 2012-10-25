using System.Collections.Generic;
using System.Linq;

namespace Miscellaneous.FoldStates.ShoppingCart
{
    public partial class CartStatePaid
    {
        public CartStatePaid(IEnumerable<Product> items, decimal amount)
        {
            Items = items.ToList();
            Amount = amount;
        }

        public IEnumerable<Product> Items { get; private set; }
        public decimal Amount { get; private set; }
    }
}
