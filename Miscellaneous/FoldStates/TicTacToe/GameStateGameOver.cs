namespace Miscellaneous.FoldStates.TicTacToe
{
public enum GameOverState
{
    XWon, YWon, Draw
}


public partial class GameStateGameOver : GameStateBase
{
    internal GameStateGameOver(MoveSequence moveSequence)
        : base(moveSequence)
    {
    }

    public GameOverState WhoWonOrDraw()
    {
        return MoveSequence.WhoWonOrDraw();
    }

    bool IGameState.IsValidMove(Row row, Col col)
    {
        return false;
    }
}
}
