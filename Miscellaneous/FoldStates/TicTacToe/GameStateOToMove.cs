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

        public IGameState OMove(Row row, Col col)
        {
            var move = new Move(row, col, Player.O);
            var newMoveSequence = MoveSequence.WithNewMove(move);
            return newMoveSequence.IsGameFinished()
                ? new GameStateGameOver(newMoveSequence)
                : new GameStateXToMove(newMoveSequence) as IGameState;
        }

        bool IGameState.IsValidMove(Row row, Col col)
        {
            return MoveSequence.IsValidMove(row, col);
        }

        Player? IGameState.WhoseTurn()
        {
            return Player.O;
        }
    }
}
