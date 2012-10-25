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

        public IGameState XMove(Row row, Col col)
        {
            var move = new Move(row, col, Player.X);
            var newMoveSequence = MoveSequence.WithNewMove(move);
            return newMoveSequence.IsGameFinished()
                ? new GameStateGameOver(newMoveSequence)
                : new GameStateOToMove(newMoveSequence) as IGameState;
        }

        bool IGameState.IsValidMove(Row row, Col col)
        {
            return MoveSequence.IsValidMove(row, col);
        }

        Player? IGameState.WhoseTurn()
        {
            return Player.X;
        }

    }
}
