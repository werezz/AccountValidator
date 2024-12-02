using AccountValidator.Models;
using AccountValidator.Services;
using AccountValidator.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using NSubstitute;

namespace AccountValidatorTests
{
    internal class CustomerAccountUploadHandlerTests
    {

        private readonly ICustomerAccountUploadHandler _customerAccountUploadHandler;
        private readonly ILogger<CustomerAccountUploadHandler> _logger;

        public CustomerAccountUploadHandlerTests()
        {
            _logger = Substitute.For<ILogger<CustomerAccountUploadHandler>>();
            _customerAccountUploadHandler = new CustomerAccountUploadHandler(_logger);
        }

        [Test]
        public void CheckIfFileIsNullOrEmpty_ReturnsTrue_WhenFileIsNullOrEmpty()
        {
            var mockFile = Substitute.For<IFormFile>();

            mockFile.Length.Returns(0);

            var result = _customerAccountUploadHandler.CheckIfFileIsNullOrEmpty(mockFile);

            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void CheckIfFileIsNullOrEmpty_ReturnsFalse_WhenFileIsNotNullOrEmpty()
        {
            var mockFile = Substitute.For<IFormFile>();

            mockFile.Length.Returns(1);

            var result = _customerAccountUploadHandler.CheckIfFileIsNullOrEmpty(mockFile);

            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public void UpLoad_ReturnsData_FromFormFile()
        {
            var mockFile = Substitute.For<IFormFile>();

            mockFile.Length.Returns(1);

            var result = _customerAccountUploadHandler.Upload(mockFile);

            Assert.That(result, Is.InstanceOf<Request>());
        }
    }
}
