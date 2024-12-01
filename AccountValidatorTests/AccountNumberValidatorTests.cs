using AccountValidator.Services.Interfaces;
using AccountValidator.Services;

namespace AccountValidatorTests
{
    internal class AccountNumberValidatorTests
    {
        private readonly IAccountNumberValidator _accountNumberValidator;
        public AccountNumberValidatorTests()
        {
            _accountNumberValidator = new AccountNumberValidator();
        }

        [Test]
        public void ValidateAccount_ReturnsTrue_WhenAccountNumberIsNumerical()
        {
            var content = "3299992";
            var result = _accountNumberValidator.ValidateAccountNumber(content);

            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void ValidateAccount_ReturnsFalse_WhenAccountNumberIsNotNumerical()
        {
            var content = "329999.";
            var result = _accountNumberValidator.ValidateAccountNumber(content);

            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public void ValidateAccount_ReturnsFalse_WhenAccountNumberIsTooLong()
        {
            var content = "32999921";
            var result = _accountNumberValidator.ValidateAccountNumber(content);

            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public void ValidateAccount_ReturnsFalse_WhenAccountNumberDoesNotStartWith3()
        {
            var content = "12999921";
            var result = _accountNumberValidator.ValidateAccountNumber(content);

            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public void ValidateAccount_ReturnsTrue_WhenAccountNumberDoesStartWith3()
        {
            var content = "3299992";
            var result = _accountNumberValidator.ValidateAccountNumber(content);

            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void ValidateAccount_ReturnsFalse_WhenAccountNumberDoesNotStartWith4()
        {
            var content = "12999921";
            var result = _accountNumberValidator.ValidateAccountNumber(content);

            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public void ValidateAccount_ReturnsTrue_WhenAccountNumberDoesStartWith4()
        {
            var content = "4299992";
            var result = _accountNumberValidator.ValidateAccountNumber(content);

            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void ValidateAccount_ReturnsTrue_WhenAccountNumberHasSpecialCharacter()
        {
            var content = "3113902p";
            var result = _accountNumberValidator.ValidateAccountNumber(content);

            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void ValidateAccount_ReturnsTrue_WhenAccountNumberIsRighSizeWihtSpecialCharacter()
        {
            var content = "3113902p";
            var result = _accountNumberValidator.ValidateAccountNumber(content);

            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void ValidateAccount_ReturnsTrue_WhenAccountNumberIsRighSize()
        {
            var content = "3113902";
            var result = _accountNumberValidator.ValidateAccountNumber(content);

            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void ValidateAccount_ReturnsFalse_WhenAccountNumberIsTooShort()
        {
            var content = "329999";
            var result = _accountNumberValidator.ValidateAccountNumber(content);

            Assert.That(result, Is.EqualTo(false));
        }
    }
}
