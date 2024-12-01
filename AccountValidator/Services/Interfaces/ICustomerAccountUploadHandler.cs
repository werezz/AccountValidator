using AccountValidator.Models;

namespace AccountValidator.Services.Interfaces
{
    public interface ICustomerAccountUploadHandler
    {
        Request Upload(IFormFile file);
        bool CheckIfFileIsNullOrEmpty(IFormFile file);
    }
}
