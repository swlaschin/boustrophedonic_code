// ============================================================================
// Auto-generated. Do not edit!
//
// To add functionality, create and edit the partial class in a separate file. 
// ============================================================================

using System;

namespace Miscellaneous.FoldStates.Email
{


	// ======================================
	// partial Interface
	// ======================================
	[System.CodeDom.Compiler.GeneratedCodeAttribute("T4Template:FoldStates.ttinclude","1.0.0")] 
	partial interface IEmailAddress 
	{
		IEmailAddress Transition(Func<EmailAddress, IEmailAddress> emailAddress, Func<ValidEmailAddress, IEmailAddress> validEmailAddress);
		void Action(Action<EmailAddress> emailAddress, Action<ValidEmailAddress> validEmailAddress);
		TObject Func<TObject>(Func<EmailAddress, TObject> emailAddress, Func<ValidEmailAddress, TObject> validEmailAddress);
	}


	
	// ======================================
	// partial class for each state
	// ======================================
	[System.CodeDom.Compiler.GeneratedCodeAttribute("T4Template:FoldStates.ttinclude","1.0.0")] 
	partial class EmailAddress : IEmailAddress 
	{
		IEmailAddress IEmailAddress.Transition(Func<EmailAddress, IEmailAddress> emailAddress, Func<ValidEmailAddress, IEmailAddress> validEmailAddress)
		{
			return emailAddress(this);
		}

		void IEmailAddress.Action(Action<EmailAddress> emailAddress, Action<ValidEmailAddress> validEmailAddress)
		{
			emailAddress(this);
		}

		TObject IEmailAddress.Func<TObject>(Func<EmailAddress, TObject> emailAddress, Func<ValidEmailAddress, TObject> validEmailAddress)
		{
			return emailAddress(this);
		}

	}

	
	// ======================================
	// partial class for each state
	// ======================================
	[System.CodeDom.Compiler.GeneratedCodeAttribute("T4Template:FoldStates.ttinclude","1.0.0")] 
	partial class ValidEmailAddress : IEmailAddress 
	{
		IEmailAddress IEmailAddress.Transition(Func<EmailAddress, IEmailAddress> emailAddress, Func<ValidEmailAddress, IEmailAddress> validEmailAddress)
		{
			return validEmailAddress(this);
		}

		void IEmailAddress.Action(Action<EmailAddress> emailAddress, Action<ValidEmailAddress> validEmailAddress)
		{
			validEmailAddress(this);
		}

		TObject IEmailAddress.Func<TObject>(Func<EmailAddress, TObject> emailAddress, Func<ValidEmailAddress, TObject> validEmailAddress)
		{
			return validEmailAddress(this);
		}

	}

	
}