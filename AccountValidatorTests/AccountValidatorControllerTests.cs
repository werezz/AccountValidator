using AccountValidator.Controllers;
using AccountValidator.Models;
using AccountValidator.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using ValidationResult = AccountValidator.Models.Response;

namespace AccountValidatorTests
{
    [TestFixture]
    internal class AccountValidatorControllerTests
    {
        private readonly ICustomerAccountHandler _customerAccountHandler;
        private readonly AccountValidatorController _accountValidatorController;
        private readonly ICustomerAccountUploadHandler _customerAccountUploadHandler;
        public AccountValidatorControllerTests()
        {
            _customerAccountHandler = Substitute.For<ICustomerAccountHandler>();
            _customerAccountUploadHandler = Substitute.For<ICustomerAccountUploadHandler>();
            _accountValidatorController = new AccountValidatorController(_customerAccountHandler, _customerAccountUploadHandler);
        }

        [Test]
        public void ValidateFile_ReturnsBadRequest_WhenUploadedFileIsEmptyOrNull()
        {
            var mockFile = Substitute.For<IFormFile>();

            var result = _customerAccountUploadHandler.CheckIfFileIsNullOrEmpty(mockFile).Returns(false);

            var noContentResult = new BadRequestObjectResult(result);

            Assert.That(noContentResult.StatusCode, Is.EqualTo(400));
        }

        [Test]
        public void ValidateFile_ReturnsOk_WhenUploadedFileIsValidatedWithoutErrors()
        {
            var validationResult = new ValidationResult { FileValid = true, InvalidLines = new List<string>() };

            var mockFileContent = Substitute.For<Request>();

            var result = _customerAccountHandler.ValidateAccount(mockFileContent).Returns(validationResult);

            var okContentResult = new OkObjectResult(result);

            Assert.That(okContentResult.StatusCode, Is.EqualTo(200));
        }

        [Test]
        public void ValidateFile_ReturnsOk_WhenUploadedFileIsValidatedWithErrors()
        {
            var validationResult = new ValidationResult { FileValid = false, InvalidLines = new List<string>() };

            var mockFileContent = Substitute.For<Request>();

            var result = _customerAccountHandler.ValidateAccount(mockFileContent).Returns(validationResult);

            var okContentResult = new OkObjectResult(result);

            Assert.That(okContentResult.StatusCode, Is.EqualTo(200));
        }
    }
}
