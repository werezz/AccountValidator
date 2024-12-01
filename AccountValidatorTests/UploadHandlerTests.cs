using AccountValidator.Models;
using AccountValidator.Services;
using AccountValidator.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using NSubstitute;

namespace AccountValidatorTests
{
    internal class UploadHandlerTests
    {

        private readonly ICustomerAccountUploadHandler _uploadHandler;
        public UploadHandlerTests()
        {
            _uploadHandler = new CustomerAccountUploadHandler();
        }

        [Test]
        public void CheckIfFileIsNullOrEmpty_ReturnsTrue_WhenFileIsNullOrEmpty()
        {
            var mockFile = Substitute.For<IFormFile>();

            mockFile.Length.Returns(0);

            var result = _uploadHandler.CheckIfFileIsNullOrEmpty(mockFile);

            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void CheckIfFileIsNullOrEmpty_ReturnsFalse_WhenFileIsNotNullOrEmpty()
        {
            var mockFile = Substitute.For<IFormFile>();

            mockFile.Length.Returns(1);

            var result = _uploadHandler.CheckIfFileIsNullOrEmpty(mockFile);

            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public void UpLoad_ReturnsData_FromFormFile()
        {
            var mockFile = Substitute.For<IFormFile>();

            mockFile.Length.Returns(1);

            var result = _uploadHandler.Upload(mockFile);

            Assert.That(result, Is.InstanceOf<Request>());
        }
    }
}
