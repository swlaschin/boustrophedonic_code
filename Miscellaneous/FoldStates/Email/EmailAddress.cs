using System;

namespace Miscellaneous.FoldStates.Email
{
    public partial class EmailAddress 
    {
        public EmailAddress(string emailAddress)
        {
            Address = emailAddress;
        }

        public string Address { get; protected set; }

        /// <summary>
        /// Create a new email address
        /// </summary>
        /// <param name="emailAddress"></param>
        /// <returns></returns>
        static public IEmailAddress New(string emailAddress)
        {
            try
            {
                // do the validation in the ValidEmailAddress itself so that it is impossible to create an invalid one
                return new ValidEmailAddress(emailAddress);
            }
            catch (ArgumentException)
            {
                return new EmailAddress(emailAddress);
            }
        }
    }
}