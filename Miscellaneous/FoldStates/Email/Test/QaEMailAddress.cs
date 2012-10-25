using NUnit.Framework;

namespace Miscellaneous.FoldStates.Email.Test
{
    /// <summary>
    /// 
    /// Creation
    /// * If the address is null, the address is not valid
    /// * If the address is empty, the address is not valid
    /// * If the address does not contain "@", the address is not valid
    /// * If the address does contain "@", the address is valid
    /// 
    /// Usage
    /// * You cannot send email to an invalid address
    /// </summary>
    [TestFixture]
    public class QaEMailAddress
    {
        [Test]
        public void OnCreationWithNullExpectInvalidAddress()
        {
            var email = EmailAddress.New(null);

            var isValid = email.Func(invalid => false, valid => true);
            Assert.IsFalse(isValid);
        }

        [Test]
        public void OnCreationWithBlankExpectInvalidAddress()
        {
            var email = EmailAddress.New("");

            var isValid = email.Func(invalid => false, valid => true);
            Assert.IsFalse(isValid);
        }

        [Test]
        public void OnCreationWithNoAtSignExpectInvalidAddress()
        {
            var email = EmailAddress.New("no at sign");

            var isValid = email.Func(invalid => false, valid => true);
            Assert.IsFalse(isValid);
        }

        [Test]
        public void OnCreationWithAtSignExpectValidAddress()
        {
            var email = EmailAddress.New("x@example.com");

            var isValid = email.Func(invalid => false, valid => true);
            Assert.IsTrue(isValid);
        }

        [Test]
        public void CannotSendEmailToInvalidAddress()
        {
            var email = EmailAddress.New("x@example.com");

            //email.Action(
            //    invalid => invalid.SendMessage("bob@example.com", "hello"), 
            //    valid => valid.SendMessage("bob@example.com", "hello")
            //    );

            email.Action(
                invalid => { }, 
                valid => valid.SendMessage("bob@example.com", "hello")
                );
        }

    }
}
