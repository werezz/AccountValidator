namespace AccountValidator.Services.Interfaces
{
    public interface IAccountNumberValidator
    {
        bool ValidateAccountNumber(string accountNumber);
    }
}