using System;

// ================================================
// From the book "Professional Enterprise .NET" 
// by Jon Arking and Scott Millett
//
// http://www.amazon.com/Professional-Enterprise-NET-Wrox-Programmer/dp/0470447613
// ================================================

namespace Miscellaneous.FoldStates.TicTacToe.NonFoldImplementation
{
    public enum Column
    {
        One = 0,
        Two = 1,
        Three = 2
    }

    public enum Row
    {
        One = 0,
        Two = 1,
        Three = 2
    }

    public enum Player
    {
        X = 1,
        O = 2
    }

    public enum GameStatus
    {
        PlayerXWins = 1,
        PlayerOWins = 2,
        GameDrawn = 3,
        AwaitingPlayerXToPlaceMarker = 4,
        AwaitingPlayerOToPlaceMarker = 5
    }

    public class TicTacToeGame
    {
        private readonly int[,] _board = new int[3, 3];
        private Player _currentplayer;

        public TicTacToeGame()
        {
            _currentplayer = Player.X;
        }

        public Player WhoseTurn()
        {
            return _currentplayer;
        }

        public bool CanPlaceMarkerAt(Row row, Column column)
        {
            if (Status() == GameStatus.AwaitingPlayerOToPlaceMarker |
                Status() == GameStatus.AwaitingPlayerXToPlaceMarker)
            {
                return _board[(int)row, (int)column] == 0;
            }

            return false;
        }

        public void PlaceMarkerAt(Row row, Column column)
        {
            if (CanPlaceMarkerAt(row, column))
            {
                _board[(int)row, (int)column] = (int)WhoseTurn();
                ChangeCurrentPlayer();
            }
            else
            {
                throw new ApplicationException(
                    string.Format("Square Row:{0}, Column:{1} already occupied by {2}", row.ToString(),
                                    column.ToString(), (Player)Enum.ToObject(typeof(Player), _board[(int)row,
                                                                                                    (int)column])));
            }
        }

        private void ChangeCurrentPlayer()
        {
            _currentplayer = _currentplayer == Player.X ? Player.O : Player.X;
        }

        public GameStatus Status()
        {
            GameStatus gameStatus;

            if (IsAWinner(Player.O))
                gameStatus = GameStatus.PlayerOWins;
            else if (IsAWinner(Player.X))
                gameStatus = GameStatus.PlayerXWins;
            else if (GameIsADraw())
                gameStatus = GameStatus.GameDrawn;
            else if (WhoseTurn() == Player.X)
                gameStatus = GameStatus.AwaitingPlayerXToPlaceMarker;
            else
                gameStatus = GameStatus.AwaitingPlayerOToPlaceMarker;

            return gameStatus;
        }

        private bool GameIsADraw()
        {
            bool allSquaresUsed = true;
            for (var row = 0; row <= 2; row++)
            {
                for (var column = 0; column <= 2; column++)
                {
                    if (_board[row, column] == 0)
                    {
                        allSquaresUsed = false;
                    }
                }
            }
            return allSquaresUsed;
        }

        private bool IsAWinner(Player player)
        {
            var winner = IsThreeInARowWinner(player) | IsThreeInAColumnWinner(player) | IsThreeInADiagonalWinner(player);

            return winner;
        }

        private bool IsThreeInADiagonalWinner(Player player)
        {
            bool winner = (_board[(int)Row.One, (int)Column.One] == (int)player &&
                           _board[(int)Row.Two, (int)Column.Two] == (int)player &&
                           _board[(int)Row.Three, (int)Column.Three] == (int)player);

            if ((_board[(int)Row.One, (int)Column.Three] == (int)player &&
                 _board[(int)Row.Two, (int)Column.Two] == (int)player &&
                 _board[(int)Row.Three, (int)Column.One] == (int)player))
            {
                winner = true;
            }

            return winner;
        }

        private bool IsThreeInAColumnWinner(Player player)
        {
            var winner = false;
            for (var column = 0; column <= 2; column++)
            {
                if ((_board[(int)Row.One, column] == (int)player && _board[(int)Row.Two, column] == (int)player &&
                     _board[(int)Row.Three, column] == (int)player))
                {
                    winner = true;
                }
            }

            return winner;
        }

        private bool IsThreeInARowWinner(Player player)
        {
            var winner = false;
            for (var row = 0; row <= 2; row++)
            {
                if ((_board[row, (int)Column.One] == (int)player && _board[row, (int)Column.Two] == (int)player &&
                     _board[row, (int)Column.Three] == (int)player))
                {
                    winner = true;
                }
            }

            return winner;
        }
    }
}