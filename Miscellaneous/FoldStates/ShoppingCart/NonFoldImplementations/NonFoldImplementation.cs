namespace Miscellaneous.FoldStates.ShoppingCart.NonFoldImplementations
{
    internal class NonFoldImplementation1
    {
        private interface ICartState
        {
            ICartState AddItem(Product product);
            ICartState RemoveItem(Product product);
            ICartState PayForCart(decimal amount);
        }

        private class CartStateEmpty : ICartState
        {
            public ICartState AddItem(Product product)
            {
                // do useful code
                return this;
            }

            public ICartState RemoveItem(Product product)
            {
                // throw not implemented exception or ignore
                return this;
            }

            public ICartState PayForCart(decimal amount)
            {
                // throw not implemented exception or ignore
                return this;
            }
        }

    }


    internal class NonFoldImplementation2
    {
        private interface ICartState
        {
        }

        private class CartStateEmpty : ICartState
        {
            public ICartState AddItem(Product product)
            {
                // do useful code
                return this;
            }

        }

        private class CartStateActive : ICartState
        {
            public ICartState AddItem(Product product)
            {
                // do useful code
                return this;
            }

            public ICartState RemoveItem(Product product)
            {
                // throw not implemented exception or ignore
                return this;
            }

            public ICartState PayForCart(decimal amount)
            {
                // throw not implemented exception or ignore
                return this;
            }
        }

        private class CartStatePaid : ICartState
        {
            public decimal GetAmountPaid()
            {
                return 0m;
            }
        }

        private class CientWithDowncasting
        {
            public ICartState AddProduct(ICartState currentState, Product product)
            {
                var cartStateEmpty = currentState as CartStateEmpty; //CAST!
                if (cartStateEmpty != null)
                {
                    return cartStateEmpty.AddItem(Product.ProductY);
                }

                var cartStateActive = currentState as CartStateActive; //CAST!
                if (cartStateActive != null)
                {
                    return cartStateActive.AddItem(Product.ProductY);
                }

                // paid state -- do nothing    
                return currentState;
            }
        }

    }


    internal class NonFoldImplementation3
    {
        private interface ICartState
        {
            ICartState Accept(ICartStateVisitor visitor);
        }

        private class CartStateEmpty : ICartState
        {
            public ICartState AddItem(Product product)
            {
                // do useful code
                return this;
            }

            public ICartState Accept(ICartStateVisitor visitor)
            {
                return visitor.VisitEmpty(this);
            }
        }

        private class CartStateActive : ICartState
        {
            public ICartState AddItem(Product product)
            {
                // do useful code
                return this;
            }

            public ICartState RemoveItem(Product product)
            {
                // throw not implemented exception or ignore
                return this;
            }

            public ICartState PayForCart(decimal amount)
            {
                // throw not implemented exception or ignore
                return this;
            }

            public ICartState Accept(ICartStateVisitor visitor)
            {
                return visitor.VisitActive(this);
            }

        }

        private class CartStatePaid : ICartState
        {
            public decimal GetAmountPaid()
            {
                return 0m;
            }

            public ICartState Accept(ICartStateVisitor visitor)
            {
                return visitor.VisitPaid(this);
            }

        }


        interface ICartStateVisitor
        {
            ICartState VisitEmpty(CartStateEmpty empty);
            ICartState VisitActive(CartStateActive active);
            ICartState VisitPaid(CartStatePaid paid);
        }

        private class CientWithVisitor
        {
            class AddProductVisitor : ICartStateVisitor
            {
                public Product productToAdd;
                public ICartState VisitEmpty(CartStateEmpty empty) { empty.AddItem(productToAdd); return empty; }
                public ICartState VisitActive(CartStateActive active) { active.AddItem(productToAdd); return active; }
                public ICartState VisitPaid(CartStatePaid paid) { return paid; }
            }

            class PayForCartVisitor : ICartStateVisitor
            {
                public decimal amountToPay;
                public ICartState VisitEmpty(CartStateEmpty empty) { return empty; }
                public ICartState VisitActive(CartStateActive active) { active.PayForCart(amountToPay); return active; }
                public ICartState VisitPaid(CartStatePaid paid) { return paid; }
            }


            public ICartState AddProduct(ICartState currentState, Product product)
            {
                var visitor = new AddProductVisitor() { productToAdd = product };
                return currentState.Accept(visitor);
            }

            public ICartState PayForCart(ICartState currentState, decimal amountToPay)
            {
                var visitor = new PayForCartVisitor() { amountToPay = amountToPay };
                return currentState.Accept(visitor);
            }

        }
    }

}