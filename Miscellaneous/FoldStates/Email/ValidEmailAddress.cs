using System;

namespace Miscellaneous.FoldStates.Email
{
    public partial class ValidEmailAddress 
    {
        public ValidEmailAddress(string emailAddress)
        {
            // do validation here
            if (string.IsNullOrEmpty(emailAddress) || !emailAddress.Contains("@"))
            {
                throw new ArgumentException("emailAddress");
            }

            Address = emailAddress;
        }

        public string Address { get; protected set; }

        /// <summary>
        /// This method is only available for the ValidEmailAddress
        /// </summary>
        public void SendMessage(string from, string subject)
        {
            Console.WriteLine("To: {0} From: {1} Re: {2}", Address, from, subject);
        }
    }
}