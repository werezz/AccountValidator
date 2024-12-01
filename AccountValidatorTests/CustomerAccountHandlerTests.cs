using AccountValidator.Services.Interfaces;
using AccountValidator.Services;
using NSubstitute;
using Microsoft.Extensions.Logging;
using AccountValidator.Models;

namespace AccountValidatorTests
{
    internal class CustomerAccountHandlerTests
    {

        private readonly IAccountNameValidator _accountNameValidator;
        private readonly IAccountNumberValidator _accountNumberValidator;
        private readonly ICustomerAccountHandler _customerAccountHandler;
        private readonly ILogger<CustomerAccountHandler> _logger;
        public CustomerAccountHandlerTests()
        {
            _accountNameValidator = Substitute.For<IAccountNameValidator>();
            _accountNumberValidator = Substitute.For<IAccountNumberValidator>();
            _logger = Substitute.For<ILogger<CustomerAccountHandler>>();
            _customerAccountHandler = new CustomerAccountHandler(_accountNameValidator, _accountNumberValidator, _logger);
        }

        [Test]
        public void ValidateAccount_ReturnsFalse_WhenAccountNumberIsTooLong()
        {
            _accountNameValidator.ValidateAccountName(Arg.Any<string>()).Returns(true);
            _accountNumberValidator.ValidateAccountNumber("32999921").Returns(false);
            var content = new Request { Accounts = new List<Account>() { new Account { Name = "Thomas", Number = "32999921", LineNumber = 1 } } };

            var result = _customerAccountHandler.ValidateAccount(content);

            Assert.That(result.InvalidLines[0], Does.Contain("Account number -not valid for line 1 'Thomas 32999921'"));
            Assert.That(result.FileValid, Is.EqualTo(false));
        }

        [Test]
        public void ValidateAccount_ReturnsFalse_WhenAccountNumberIsTooShort()
        {
            _accountNameValidator.ValidateAccountName(Arg.Any<string>()).Returns(true);
            _accountNumberValidator.ValidateAccountNumber("329999").Returns(false);
            var content = new Request { Accounts = new List<Account>() { new Account { Name = "Thomas", Number = "329999", LineNumber = 1 } } };

            var result = _customerAccountHandler.ValidateAccount(content);

            Assert.That(result.InvalidLines[0], Does.Contain("Account number -not valid for line 1 'Thomas 329999'"));
            Assert.That(result.FileValid, Is.EqualTo(false));
        }

        [Test]
        public void ValidateAccount_ReturnsFalse_WhenAccountNumberDoesNotStartWith3()
        {
            _accountNameValidator.ValidateAccountName(Arg.Any<string>()).Returns(true);
            _accountNumberValidator.ValidateAccountNumber("12999921").Returns(false);
            var content = new Request { Accounts = new List<Account>() { new Account { Name = "Thomas", Number = "12999921", LineNumber = 1 } } };

            var result = _customerAccountHandler.ValidateAccount(content);

            Assert.That(result.InvalidLines[0], Does.Contain("Account number -not valid for line 1 'Thomas 12999921'"));
            Assert.That(result.FileValid, Is.EqualTo(false));
        }

        [Test]
        public void ValidateAccount_ReturnsTrue_WhenAccountNumberDoesStartWith3()
        {
            _accountNameValidator.ValidateAccountName(Arg.Any<string>()).Returns(true);
            _accountNumberValidator.ValidateAccountNumber("3299992").Returns(true);
            var content = new Request { Accounts = new List<Account>() { new Account { Name = "Thomas", Number = "3299992", LineNumber = 1 } } };

            var result = _customerAccountHandler.ValidateAccount(content);

            Assert.That(result.FileValid, Is.EqualTo(true));
        }

        [Test]
        public void ValidateAccount_ReturnsFalse_WhenAccountNumberDoesNotStartWith4()
        {
            _accountNameValidator.ValidateAccountName(Arg.Any<string>()).Returns(true);
            _accountNumberValidator.ValidateAccountNumber("12999921").Returns(false);
            var content = new Request { Accounts = new List<Account>() { new Account { Name = "Thomas", Number = "12999921", LineNumber = 1 } } };

            var result = _customerAccountHandler.ValidateAccount(content);

            Assert.That(result.InvalidLines[0], Does.Contain("Account number -not valid for line 1 'Thomas 12999921'"));
            Assert.That(result.FileValid, Is.EqualTo(false));
        }

        [Test]
        public void ValidateAccount_ReturnsTrue_WhenAccountNumberDoesStartWith4()
        {
            _accountNameValidator.ValidateAccountName(Arg.Any<string>()).Returns(true);
            _accountNumberValidator.ValidateAccountNumber("4299992").Returns(true);
            var content = new Request { Accounts = new List<Account>() { new Account { Name = "Thomas", Number = "4299992", LineNumber = 1 } } };

            var result = _customerAccountHandler.ValidateAccount(content);

            Assert.That(result.FileValid, Is.EqualTo(true));
        }

        [Test]
        public void ValidateAccount_ReturnsFalse_WhenAccountNameDoesNotStartUpperCase()
        {
            _accountNameValidator.ValidateAccountName("michael").Returns(false);
            _accountNumberValidator.ValidateAccountNumber(Arg.Any<string>()).Returns(true);
            var content = new Request { Accounts = new List<Account>() { new Account { Name = "michael", Number = "3113902", LineNumber = 1 } } };

            var result = _customerAccountHandler.ValidateAccount(content);

            Assert.That(result.InvalidLines[0], Does.Contain("Account name -not valid for line 1 'michael 3113902'"));
            Assert.That(result.FileValid, Is.EqualTo(false));
        }

        [Test]
        public void ValidateAccount_ReturnsFalse_WhenAccountNameIsNotAlphabetical()
        {
            _accountNameValidator.ValidateAccountName("XAEA-12").Returns(false);
            _accountNumberValidator.ValidateAccountNumber(Arg.Any<string>()).Returns(true);
            var content = new Request { Accounts = new List<Account>() { new Account { Name = "XAEA-12", Number = "3293982", LineNumber = 1 } } };

            var result = _customerAccountHandler.ValidateAccount(content);

            Assert.That(result.InvalidLines[0], Does.Contain("Account name -not valid for line 1 'XAEA-12 3293982'"));
            Assert.That(result.FileValid, Is.EqualTo(false));
        }

        [Test]
        public void ValidateAccount_ReturnsTrue_WhenAccountNumberHasSpecialCharacter()
        {
            _accountNameValidator.ValidateAccountName(Arg.Any<string>()).Returns(true);
            _accountNumberValidator.ValidateAccountNumber("3113902p").Returns(true);
            var content = new Request { Accounts = new List<Account>() { new Account { Name = "Rob", Number = "3113902p", LineNumber = 1 } } };

            var result = _customerAccountHandler.ValidateAccount(content);

            Assert.That(result.FileValid, Is.EqualTo(true));
        }

        [Test]
        public void ValidateAccount_ReturnsTrue_WhenAccountNumberIsRighSizeWihtSpecialCharacter()
        {
            _accountNameValidator.ValidateAccountName(Arg.Any<string>()).Returns(true);
            _accountNumberValidator.ValidateAccountNumber("3113902p").Returns(true);
            var content = new Request { Accounts = new List<Account>() { new Account { Name = "Rob", Number = "3113902p", LineNumber = 1 } } };

            var result = _customerAccountHandler.ValidateAccount(content);

            Assert.That(result.FileValid, Is.EqualTo(true));
        }

        [Test]
        public void ValidateAccount_ReturnsTrue_WhenAccountNumberIsRighSize()
        {
            _accountNameValidator.ValidateAccountName(Arg.Any<string>()).Returns(true);
            _accountNumberValidator.ValidateAccountNumber("3113902").Returns(true);
            var content = new Request { Accounts = new List<Account>() { new Account { Name = "Rob", Number = "3113902", LineNumber = 1 } } };

            var result = _customerAccountHandler.ValidateAccount(content);

            Assert.That(result.FileValid, Is.EqualTo(true));
        }

        [Test]
        public void ValidateAccount_ReturnsTrue_WhenAccountNameStartsUpperCase()
        {
            _accountNameValidator.ValidateAccountName("Rob").Returns(true);
            _accountNumberValidator.ValidateAccountNumber(Arg.Any<string>()).Returns(true);
            var content = new Request { Accounts = new List<Account>() { new Account { Name = "Rob", Number = "3113902", LineNumber = 1 } } };

            var result = _customerAccountHandler.ValidateAccount(content);

            Assert.That(result.FileValid, Is.EqualTo(true));
        }
    }
}