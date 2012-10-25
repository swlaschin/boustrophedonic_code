namespace Miscellaneous.FoldStates.TicTacToe
{
    public partial interface IGameState 
    {
        bool IsValidMove(Row row, Col col);

        Player? WhoseTurn();
    }
}
