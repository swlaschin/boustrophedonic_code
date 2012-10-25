using System;
using NUnit.Framework;

namespace Miscellaneous.FoldStates.TicTacToe.Test
{
    /// <summary>
    /// Example from Chapter 4 of Professional Enterprise .NET by By Jon Arking, Scott Millett
    /// 
    /// Player X is the first Player to place a marker. 
    /// A Player cannot place a marker on a full square. 
    /// After Player X places an X marker the square is unavailable. 
    /// Player O will be next to take a turn after Player X has placed a marker. 
    /// A Player cannot place a marker in a zone that does not exist. 
    /// An exception will be thrown if a Player attempts to place a marker in an occupied square. 
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
            var isXToPlay = initialState.Func(
                xToMove => true,
                oToMove => false,
                gameOver => false);
            Assert.That(isXToPlay, Is.True);
        }

        [Test]
        public void APlayerCannotPlaceAMarkerOnAFullSquare()
        {
            var initialState = TicTacToeGame.StartNewGame();
            Action<Move> invalidMoveAction = move => Console.WriteLine("The move {0} is not allowed", move);

            // X plays
            var newGameState = initialState.Transition
                (
                    xToMove => xToMove.Move(Row.Row1, Col.Col1, invalidMoveAction),
                    oToMove => oToMove,
                    gameOver => gameOver
                );

            var isValidMove = newGameState.IsValidMove(Row.Row1, Col.Col1);
            Assert.IsFalse(isValidMove);
        }

        [Test]
        public void AnErrorWillBeCaughtIfAPlayerAttemptsToPlaceAMarkerInAnOccupiedSquare()
        {
            var initialState = TicTacToeGame.StartNewGame();
            Action<Move> invalidMoveAction = move => Console.WriteLine("The move {0} is not allowed", move);

            // X plays
            var afterFirstMove = initialState.Transition
                (
                    xToMove => xToMove.Move(Row.Row1, Col.Col1, invalidMoveAction),
                    oToMove => oToMove,
                    gameOver => gameOver
                );


            bool invalidMove = false;
            Action<Move> invalidMoveAction2 = move => invalidMove = true;

            // O plays same square
            afterFirstMove.Transition
                (
                    xToMove => xToMove,
                    oToMove => oToMove.Move(Row.Row1, Col.Col1, invalidMoveAction2),
                    gameOver => gameOver
                );

            Assert.IsTrue(invalidMove);
        }

        [Test]
        public void PlayerOWillBeNextToTakeATurnAfterPlayerXHasPlacedAMarker()
        {
            var initialState = TicTacToeGame.StartNewGame();
            Action<Move> invalidMoveAction = move => Console.WriteLine("The move {0} is not allowed", move);

            // X plays
            var afterFirstMove = initialState.Transition(
                xToMove => xToMove.Move(Row.Row1, Col.Col1, invalidMoveAction),
                oToMove => oToMove,
                gameOver => gameOver);

            var isOToPlay = afterFirstMove.Func(xToMove => false, oToMove => true, gameOver => false);
            Assert.That(isOToPlay, Is.True);
        }

        /// If Player X gets three Xs in a row, then the game is won by Player X. 
        [Test]
        public void IfPlayerXGetsThreeXsInARowThenTheGameIsWonByPlayerX()
        {
            var initialState = TicTacToeGame.StartNewGame();
            Action<Move> invalidMoveAction = move => Console.WriteLine("The move {0} is not allowed", move);

            // X plays
            var move1 = initialState.Transition(
                xToMove => xToMove.Move(Row.Row1, Col.Col1, invalidMoveAction),
                oToMove => oToMove,
                gameOver => gameOver);

            // O plays
            var move2 = move1.Transition(
                xToMove => xToMove,
                oToMove => oToMove.Move(Row.Row2, Col.Col1, invalidMoveAction),
                gameOver => gameOver);

            // X plays
            var move3 = move2.Transition(
                xToMove => xToMove.Move(Row.Row1, Col.Col2, invalidMoveAction),
                oToMove => oToMove,
                gameOver => gameOver);

            // O plays
            var move4 = move3.Transition(
                xToMove => xToMove,
                oToMove => oToMove.Move(Row.Row2, Col.Col2, invalidMoveAction),
                gameOver => gameOver);

            // X plays and wins
            var move5 = move4.Transition(
                xToMove => xToMove.Move(Row.Row1, Col.Col3, invalidMoveAction),
                oToMove => oToMove,
                gameOver => gameOver);

            //var move5 = move4.Transition(
            //    xToMove => xToMove.Move(Row.Row1, Col.Col3, invalidMoveAction),
            //    oToMove => oToMove,
            //    gameOver => gameOver.Move(Row.Row1, Col.Col3, invalidMoveAction));  // compile time error

            var isGameOver = move5.Func(xToMove => false, oToMove => false, gameOver => true);
            Assert.IsTrue(isGameOver);

            GameOverState? whoWon = null;
            move5.Action(
                xToMove => { },
                oToMove => { },
                gameOver => whoWon = gameOver.WhoWonOrDraw());
            Assert.That(whoWon, Is.EqualTo(GameOverState.XWon));

            //move5.Action(
            //    xToMove => whoWon = xToMove.WhoWonOrDraw(), // compile time error
            //    oToMove => { },
            //    gameOver => whoWon = gameOver.WhoWonOrDraw());
        }
    }
}
