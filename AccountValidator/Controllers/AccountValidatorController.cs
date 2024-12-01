using AccountValidator.Services.Interfaces;
using AccountValidator.Utility;
using Microsoft.AspNetCore.Mvc;

namespace AccountValidator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountValidatorController : ControllerBase
    {
        private readonly ICustomerAccountHandler _customerAccountHandler;
        private readonly ICustomerAccountUploadHandler _customerAccountUploadHandler;

        public AccountValidatorController(ICustomerAccountHandler customerAccountHandler, ICustomerAccountUploadHandler customerAccountUploadHandler)
        {
            _customerAccountHandler = customerAccountHandler;
            _customerAccountUploadHandler = customerAccountUploadHandler;
        }

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

            return Ok(new { fileValid = response.FileValid });
        }
    }
}
