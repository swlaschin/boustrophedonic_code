namespace Miscellaneous.FoldStates.TicTacToe
{
    /// <summary>
    /// Base class for all game states
    /// </summary>
    public abstract class GameStateBase
    {
        internal protected GameStateBase(MoveSequence moveSequence)
        {
            MoveSequence = moveSequence;
        }

        internal MoveSequence MoveSequence { get; private set; }

    }
}