namespace Miscellaneous.FoldStates.TicTacToe
{
    public partial class GameStateGameOver : GameStateBase
    {
        internal GameStateGameOver(MoveSequence moveSequence)
            : base(moveSequence)
        {
        }

        bool IGameState.IsValidMove(Row row, Col col)
        {
            return false;
        }

        Player? IGameState.WhoseTurn()
        {
            return null;
        }

    }
}
