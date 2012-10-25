using System;

namespace Miscellaneous.FoldStates.TicTacToe
{
    public partial class GameStateOToMove : GameStateBase
    {
        internal GameStateOToMove()
            : base(new MoveSequence())
        {
        }

        internal GameStateOToMove(MoveSequence moveSequence)
            : base(moveSequence)
        {
        }

        public IGameState Move(Row row, Col col, Action<Move> invalidMoveCallback)
        {
            var move = new Move(row, col, Player.O);
            var newMoveSequence = MoveSequence.WithNewMove(move, invalidMoveCallback);
            return newMoveSequence.IsGameOver()
                ? new GameStateGameOver(newMoveSequence)
                : new GameStateXToMove(newMoveSequence) as IGameState;
        }

        bool IGameState.IsValidMove(Row row, Col col)
        {
            return MoveSequence.IsValidMove(row, col);
        }
    }
}
