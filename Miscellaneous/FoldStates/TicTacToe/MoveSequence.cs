using System;
using System.Collections.Generic;
using System.Linq;

namespace Miscellaneous.FoldStates.TicTacToe
{
    /// <summary>
    /// An immutable list of moves made so far.
    /// </summary>
    public class MoveSequence
    {
        /// <summary>
        /// Create a new non-empty sequence of moves
        /// </summary>
        internal MoveSequence(IEnumerable<Move> moves)
        {
            if (moves == null) throw new ArgumentNullException("moves");
            Moves = moves;
        }

        /// <summary>
        /// Create a empty sequence of moves
        /// </summary>
        internal MoveSequence()
            : this(new List<Move>())
        {
        }

        internal IEnumerable<Move> Moves
        {
            get;
            private set;
        }

        internal MoveSequence WithNewMove(Move move)
        {
            if (!IsValidMove(move.Row, move.Col))
            {
                throw new InvalidMoveException(move);
            }

            var moves = Moves.ToList();
            moves.Add(move);
            return new MoveSequence(moves);
        }

        internal bool IsValidMove(Row row, Col col)
        {
            return !Moves.Any(m => m.IsSameSquare(row, col));
        }

        internal bool IsGameFinished()
        {
            // put detailed logic here. For now just assume X wins after three!
            return Moves.Count(m => m.Player == Player.X) == 3;
        }

        internal bool CanPlay(Row row, Col col)
        {
            return true;
        }
    }
}