using NUnit.Framework;

namespace Miscellaneous.FoldStates.TicTacToe.Test
{
    /// <summary>
    /// Example from Chapter 4 of Professional Enterprise .NET by By Jon Arking, Scott Millett
    /// 
    /// Player X is the first player to place a marker. 
    /// A player cannot place a marker on a full square. 
    /// After Player X places an X marker the square is unavailable. 
    /// Player O will be next to take a turn after Player X has placed a marker. 
    /// A player cannot place a marker in a zone that does not exist. 
    /// An exception will be thrown if a player attempts to place a marker in an occupied square. 
    /// If Player X gets three Xs in a row, then the game is won by Player X. 
    /// If Player X gets three Xs in a column, then the game is won by Player X. 
    /// If Player X Gets three Xs in a diagonal line the game is won by Player X. 
    /// When all squares are full and there is no winner, the game is a draw.
    /// </summary>
    [TestFixture]
    public class QaTicTacToe
    {
        [Test]
        public void PlayerXIsTheFirstPlayerToPlaceAMarker()
        {
            var initialState = TicTacToeGame.StartNewGame();
            Assert.AreEqual(Player.X, initialState.WhoseTurn());

        }

        [Test]
        public void APlayerCannotPlaceAMarkerOnAFullSquare()
        {
            var initialState = TicTacToeGame.StartNewGame();

            // X plays
            var newGameState = initialState.Transition
                (
                    xToMove => xToMove.XMove(Row.Row1, Col.Col1),
                    oToMove => oToMove,
                    gameOver => gameOver
                );

            var isValidMove = newGameState.IsValidMove(Row.Row1, Col.Col1);
            Assert.IsFalse(isValidMove);
        }

        [Test]
        public void AnExceptionWillBeThrownIfAPlayerAttemptsToPlaceAMarkerInAnOccupiedSquare()
        {
            var initialState = TicTacToeGame.StartNewGame();

            // X plays
            var afterFirstMove = initialState.Transition
                (
                    xToMove => xToMove.XMove(Row.Row1, Col.Col1),
                    oToMove => oToMove,
                    gameOver => gameOver
                );

            try
            {

                // O plays same square
                afterFirstMove.Transition
                    (
                        xToMove => xToMove,
                        oToMove => oToMove.OMove(Row.Row1, Col.Col1),
                        gameOver => gameOver
                    );

                Assert.Fail("expecting InvalidMoveException");
            }
            catch (InvalidMoveException)
            {
            }

        }

        [Test]
        public void PlayerOWillBeNextToTakeATurnAfterPlayerXHasPlacedAMarker()
        {
            var initialState = TicTacToeGame.StartNewGame();

            // X plays
            var afterFirstMove = initialState.Transition(xToMove => xToMove.XMove(Row.Row1, Col.Col1), oToMove => oToMove, gameOver => gameOver);

            Assert.AreEqual(Player.O, afterFirstMove.WhoseTurn());

            var oTransitioned = afterFirstMove.Func(xToMove => false, oToMove => true, gameOver => false);
            Assert.IsTrue(oTransitioned);

        }

        /// If Player X gets three Xs in a row, then the game is won by Player X. 
        /// [Test]
        public void IfPlayerXGetsThreeXsInARowThenTheGameIsWonByPlayerX()
        {
            var initialState = TicTacToeGame.StartNewGame();

            // X plays
            var move1 = initialState.Transition(xToMove => xToMove.XMove(Row.Row1, Col.Col1), oToMove => oToMove, gameOver => gameOver);
            // O plays
            var move2 = move1.Transition(xToMove => xToMove, oToMove => oToMove.OMove(Row.Row2, Col.Col1), gameOver => gameOver);
            // X plays
            var move3 = move2.Transition(xToMove => xToMove.XMove(Row.Row1, Col.Col2), oToMove => oToMove, gameOver => gameOver);
            // O plays
            var move4 = move3.Transition(xToMove => xToMove, oToMove => oToMove.OMove(Row.Row2, Col.Col1), gameOver => gameOver);
            // X plays and wins
            var move5 = move4.Transition(xToMove => xToMove.XMove(Row.Row1, Col.Col3), oToMove => oToMove, gameOver => gameOver);

            Assert.AreEqual(null, move5.WhoseTurn());

            var isGameOver = move5.Func(xToMove => false, oToMove => false, gameOver => true);
            Assert.IsTrue(isGameOver);

        }
    }
}
