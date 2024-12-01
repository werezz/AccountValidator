using AccountValidator.Services.Interfaces;
using AccountValidator.Services.validations;

namespace AccountValidator.Services
{
    public class AccountNameValidator: IAccountNameValidator
    {
        public bool ValidateAccountName(string accountName)
        {
            if (!new IsAlphaBetic().CheckIfStringIsAlphabetic(accountName)) return false;
            if (!new StartsUpperCase().CheckIfStartsUpperCase(accountName)) return false;

            return true;
        }
    }
}
