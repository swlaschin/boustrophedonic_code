// ============================================================================
// Auto-generated. Do not edit!
//
// To add functionality, create and edit the partial class in a separate file. 
// ============================================================================

using System;

namespace Miscellaneous.FoldStates.TicTacToe
{


	// ======================================
	// partial Interface
	// ======================================
	[System.CodeDom.Compiler.GeneratedCodeAttribute("T4Template:FoldStates.ttinclude","1.0.0")] 
	partial interface IGameState 
	{
		IGameState Transition(Func<GameStateXToMove, IGameState> gameStateXToMove, Func<GameStateOToMove, IGameState> gameStateOToMove, Func<GameStateGameOver, IGameState> gameStateGameOver);
		void Action(Action<GameStateXToMove> gameStateXToMove, Action<GameStateOToMove> gameStateOToMove, Action<GameStateGameOver> gameStateGameOver);
		TObject Func<TObject>(Func<GameStateXToMove, TObject> gameStateXToMove, Func<GameStateOToMove, TObject> gameStateOToMove, Func<GameStateGameOver, TObject> gameStateGameOver);
	}


	
	// ======================================
	// partial class for each state
	// ======================================
	[System.CodeDom.Compiler.GeneratedCodeAttribute("T4Template:FoldStates.ttinclude","1.0.0")] 
	partial class GameStateXToMove : IGameState 
	{
		IGameState IGameState.Transition(Func<GameStateXToMove, IGameState> gameStateXToMove, Func<GameStateOToMove, IGameState> gameStateOToMove, Func<GameStateGameOver, IGameState> gameStateGameOver)
		{
			return gameStateXToMove(this);
		}

		void IGameState.Action(Action<GameStateXToMove> gameStateXToMove, Action<GameStateOToMove> gameStateOToMove, Action<GameStateGameOver> gameStateGameOver)
		{
			gameStateXToMove(this);
		}

		TObject IGameState.Func<TObject>(Func<GameStateXToMove, TObject> gameStateXToMove, Func<GameStateOToMove, TObject> gameStateOToMove, Func<GameStateGameOver, TObject> gameStateGameOver)
		{
			return gameStateXToMove(this);
		}

	}

	
	// ======================================
	// partial class for each state
	// ======================================
	[System.CodeDom.Compiler.GeneratedCodeAttribute("T4Template:FoldStates.ttinclude","1.0.0")] 
	partial class GameStateOToMove : IGameState 
	{
		IGameState IGameState.Transition(Func<GameStateXToMove, IGameState> gameStateXToMove, Func<GameStateOToMove, IGameState> gameStateOToMove, Func<GameStateGameOver, IGameState> gameStateGameOver)
		{
			return gameStateOToMove(this);
		}

		void IGameState.Action(Action<GameStateXToMove> gameStateXToMove, Action<GameStateOToMove> gameStateOToMove, Action<GameStateGameOver> gameStateGameOver)
		{
			gameStateOToMove(this);
		}

		TObject IGameState.Func<TObject>(Func<GameStateXToMove, TObject> gameStateXToMove, Func<GameStateOToMove, TObject> gameStateOToMove, Func<GameStateGameOver, TObject> gameStateGameOver)
		{
			return gameStateOToMove(this);
		}

	}

	
	// ======================================
	// partial class for each state
	// ======================================
	[System.CodeDom.Compiler.GeneratedCodeAttribute("T4Template:FoldStates.ttinclude","1.0.0")] 
	partial class GameStateGameOver : IGameState 
	{
		IGameState IGameState.Transition(Func<GameStateXToMove, IGameState> gameStateXToMove, Func<GameStateOToMove, IGameState> gameStateOToMove, Func<GameStateGameOver, IGameState> gameStateGameOver)
		{
			return gameStateGameOver(this);
		}

		void IGameState.Action(Action<GameStateXToMove> gameStateXToMove, Action<GameStateOToMove> gameStateOToMove, Action<GameStateGameOver> gameStateGameOver)
		{
			gameStateGameOver(this);
		}

		TObject IGameState.Func<TObject>(Func<GameStateXToMove, TObject> gameStateXToMove, Func<GameStateOToMove, TObject> gameStateOToMove, Func<GameStateGameOver, TObject> gameStateGameOver)
		{
			return gameStateGameOver(this);
		}

	}

	
}