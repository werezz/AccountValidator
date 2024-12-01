using AccountValidator.Services.Interfaces;
using AccountValidator.Services;

namespace AccountValidatorTests
{
    internal class AccountNameValidatorTests
    {
        private readonly IAccountNameValidator _accountNameValidator;
        public AccountNameValidatorTests()
        {
            _accountNameValidator = new AccountNameValidator();
        }

        [Test]
        public void ValidateAccountName_ReturnsTrue_WhenAccountNameStartsUpperCase()
        {
            var content = "Rob";
            var result = _accountNameValidator.ValidateAccountName(content);

            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void ValidateAccountName_ReturnsFalse_WhenAccountNameDoesNotStartUpperCase()
        {
            var content = "michael";
            var result = _accountNameValidator.ValidateAccountName(content);

            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public void ValidateAccountName_ReturnsTrue_WhenAccountNameIstAlphabetical()
        {
            var content = "Rob";
            var result = _accountNameValidator.ValidateAccountName(content);

            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void ValidateAccountName_ReturnsFalse_WhenAccountNameIsNotAlphabetical()
        {
            var content = "XAEA-12";
            var result = _accountNameValidator.ValidateAccountName(content);

            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public void ValidateAccountName_ReturnsTrue_WhenAccountNameIsAlphabeticalAndStarstUpperCase()
        {
            var content = "Rob";
            var result = _accountNameValidator.ValidateAccountName(content);

            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void ValidateAccountName_ReturnsFalse_WhenAccountNameIsAlphabeticalButNotStartUpperCase()
        {
            var content = "michael";
            var result = _accountNameValidator.ValidateAccountName(content);

            Assert.That(result, Is.EqualTo(false));
        }
    }
}
