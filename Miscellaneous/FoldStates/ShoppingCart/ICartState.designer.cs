// ============================================================================
// Auto-generated. Do not edit!
//
// To add functionality, create and edit the partial class in a separate file. 
// ============================================================================

using System;

namespace Miscellaneous.FoldStates.ShoppingCart
{


    // ======================================
    // partial Interface
    // ======================================
    [System.CodeDom.Compiler.GeneratedCodeAttribute("T4Template:FoldStates.ttinclude", "1.0.0")]
    partial interface ICartState
    {
        ICartState Transition(Func<CartStateEmpty, ICartState> cartStateEmpty, Func<CartStateActive, ICartState> cartStateActive, Func<CartStatePaid, ICartState> cartStatePaid);
        void Action(Action<CartStateEmpty> cartStateEmpty, Action<CartStateActive> cartStateActive, Action<CartStatePaid> cartStatePaid);
        TObject Func<TObject>(Func<CartStateEmpty, TObject> cartStateEmpty, Func<CartStateActive, TObject> cartStateActive, Func<CartStatePaid, TObject> cartStatePaid);
    }



    // ======================================
    // partial class for each state
    // ======================================
    [System.CodeDom.Compiler.GeneratedCodeAttribute("T4Template:FoldStates.ttinclude", "1.0.0")]
    partial class CartStateEmpty : ICartState
    {
        ICartState ICartState.Transition(Func<CartStateEmpty, ICartState> cartStateEmpty, Func<CartStateActive, ICartState> cartStateActive, Func<CartStatePaid, ICartState> cartStatePaid)
        {
            return cartStateEmpty(this);
        }

        void ICartState.Action(Action<CartStateEmpty> cartStateEmpty, Action<CartStateActive> cartStateActive, Action<CartStatePaid> cartStatePaid)
        {
            cartStateEmpty(this);
        }

        TObject ICartState.Func<TObject>(Func<CartStateEmpty, TObject> cartStateEmpty, Func<CartStateActive, TObject> cartStateActive, Func<CartStatePaid, TObject> cartStatePaid)
        {
            return cartStateEmpty(this);
        }

    }


    // ======================================
    // partial class for each state
    // ======================================
    [System.CodeDom.Compiler.GeneratedCodeAttribute("T4Template:FoldStates.ttinclude", "1.0.0")]
    partial class CartStateActive : ICartState
    {
        ICartState ICartState.Transition(Func<CartStateEmpty, ICartState> cartStateEmpty, Func<CartStateActive, ICartState> cartStateActive, Func<CartStatePaid, ICartState> cartStatePaid)
        {
            return cartStateActive(this);
        }

        void ICartState.Action(Action<CartStateEmpty> cartStateEmpty, Action<CartStateActive> cartStateActive, Action<CartStatePaid> cartStatePaid)
        {
            cartStateActive(this);
        }

        TObject ICartState.Func<TObject>(Func<CartStateEmpty, TObject> cartStateEmpty, Func<CartStateActive, TObject> cartStateActive, Func<CartStatePaid, TObject> cartStatePaid)
        {
            return cartStateActive(this);
        }

    }


    // ======================================
    // partial class for each state
    // ======================================
    [System.CodeDom.Compiler.GeneratedCodeAttribute("T4Template:FoldStates.ttinclude", "1.0.0")]
    partial class CartStatePaid : ICartState
    {
        ICartState ICartState.Transition(Func<CartStateEmpty, ICartState> cartStateEmpty, Func<CartStateActive, ICartState> cartStateActive, Func<CartStatePaid, ICartState> cartStatePaid)
        {
            return cartStatePaid(this);
        }

        void ICartState.Action(Action<CartStateEmpty> cartStateEmpty, Action<CartStateActive> cartStateActive, Action<CartStatePaid> cartStatePaid)
        {
            cartStatePaid(this);
        }

        TObject ICartState.Func<TObject>(Func<CartStateEmpty, TObject> cartStateEmpty, Func<CartStateActive, TObject> cartStateActive, Func<CartStatePaid, TObject> cartStatePaid)
        {
            return cartStatePaid(this);
        }

    }


}