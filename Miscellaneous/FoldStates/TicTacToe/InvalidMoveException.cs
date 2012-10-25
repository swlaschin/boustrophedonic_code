using System;

namespace Miscellaneous.FoldStates.TicTacToe
{
    class InvalidMoveException : Exception
    {
        public InvalidMoveException(Move move)
            : base(move.ToString())
        {
            Move = move;
        }

        public Move Move { get; private set; }
    }
}
