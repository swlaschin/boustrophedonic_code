using System;

namespace Miscellaneous.FoldStates.TicTacToe
{
    public partial class GameStateXToMove : GameStateBase
    {
        internal GameStateXToMove()
            : base(new MoveSequence())
        {
        }

        internal GameStateXToMove(MoveSequence moveSequence)
            : base(moveSequence)
        {
        }

        public IGameState Move(Row row, Col col, Action<Move> invalidMoveCallback)
        {
            var move = new Move(row, col, Player.X);
            var newMoveSequence = MoveSequence.WithNewMove(move, invalidMoveCallback);
            return newMoveSequence.IsGameOver()
                ? new GameStateGameOver(newMoveSequence)
                : new GameStateOToMove(newMoveSequence) as IGameState;
        }

        bool IGameState.IsValidMove(Row row, Col col)
        {
            return MoveSequence.IsValidMove(row, col);
        }
    }
}
