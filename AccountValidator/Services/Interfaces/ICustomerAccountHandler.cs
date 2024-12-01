using AccountValidator.Models;

namespace AccountValidator.Services.Interfaces
{
    public interface ICustomerAccountHandler
    {
        Response ValidateAccount(Request fileContent);
    }
}
