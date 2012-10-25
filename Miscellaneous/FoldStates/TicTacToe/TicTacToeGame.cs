namespace Miscellaneous.FoldStates.TicTacToe
{
    public class TicTacToeGame
    {
        public static IGameState StartNewGame()
        {
            return new GameStateXToMove();
        }
    }
}
