using System;

namespace Miscellaneous.FoldStates.TicTacToe
{

    public enum Player
    {
        X, O
    }

    public enum Col
    {
        Col1, Col2, Col3
    }

    public enum Row
    {
        Row1, Row2, Row3
    }


    public struct Move : IEquatable<Move>
    {
        public Move(Row row, Col col, Player player)
            : this()
        {
            Row = row;
            Col = col;
            Player = player;
        }

        public Row Row { get; private set; }

        public Col Col { get; private set; }

        public Player Player { get; private set; }

        public bool IsSameSquare(Row otherRow, Col otherCol)
        {
            return otherRow == Row &&
                   otherCol == Col;
        }

        public bool Equals(Move other)
        {
            return other.Row == Row &&
                other.Col == Col &&
                other.Player == Player;
        }

        public override int GetHashCode()
        {
            return Row.GetHashCode() + Col.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is Move)
            {
                return Equals((Move)obj);
            }
            return false;
        }

        public override string ToString()
        {
            return string.Format("Move {0}-{1}", Row, Col);
        }

        internal bool IsSamePlayer(Move move)
        {
            return Player == move.Player;
        }
    }

}
