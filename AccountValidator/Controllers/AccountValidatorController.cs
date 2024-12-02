using AccountValidator.Services.Interfaces;
using AccountValidator.Utility;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace AccountValidator.Controllers
{
    [ApiController]
    [ApiVersion(1)]
    [Route("[controller]")]
    [ProducesResponseType(200)]
    public class AccountValidatorController : ControllerBase
    {
        private readonly ICustomerAccountHandler _customerAccountHandler;
        private readonly ICustomerAccountUploadHandler _customerAccountUploadHandler;

        public AccountValidatorController(ICustomerAccountHandler customerAccountHandler, ICustomerAccountUploadHandler customerAccountUploadHandler)
        {
            _customerAccountHandler = customerAccountHandler;
            _customerAccountUploadHandler = customerAccountUploadHandler;
        }

        [MapToApiVersion(1)]
        [HttpPost]
        public IActionResult ValidateFile(IFormFile file)
        {
            if (_customerAccountUploadHandler.CheckIfFileIsNullOrEmpty(file))
            {
                return BadRequest();
            }

            var request = _customerAccountUploadHandler.Upload(file);

            var response = _customerAccountHandler.ValidateAccount(request);

            if (!response.FileValid) return Ok(response.ToValidationResultDTO());

            return Ok(new { fileValid = true});
        }
    }
}
