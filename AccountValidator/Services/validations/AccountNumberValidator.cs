using AccountValidator.Services.Interfaces;
using AccountValidator.Services.validations;
using AccountValidator.Services.Validations.BasicValidations;

namespace AccountValidator.Services
{
    public class AccountNumberValidator : IAccountNumberValidator
    {
        const int AccountNumberLength = 7;
        const int AcountNumberFirstCaseLenght = 8;
        const char AccountNumberStartFirstCase = '3';
        const char AccountNumberStartSecondCase = '4';
        const char AcountNumberSpecialCharacter = 'p';

        public bool ValidateAccountNumber(string accountNumber)
        {
            var accountEndChecker = new EndsWithSpecifiedCharacter();
            var accountStartChecker = new StartsWithSpecifiedCharacter();
            var accountLengthChecker = new IsSpecifiedLength();
            var accountNumericalChecker = new IsNumerical();

            if (!accountNumericalChecker.CheckIfStringIsOnlyNumerical(accountNumber))
            {
                if (!accountEndChecker.CheckIfStringEndsWihtSpecifiedCharacter(accountNumber, AcountNumberSpecialCharacter)) return false;
            }

            if (!accountStartChecker.CheckIfStringStartsWihtSpecifiedCharacter(accountNumber, AccountNumberStartFirstCase))
            {
                if (!accountStartChecker.CheckIfStringStartsWihtSpecifiedCharacter(accountNumber, AccountNumberStartSecondCase)) return false;
            }

            if (!accountLengthChecker.CheckIfStringIsSpecificLength(accountNumber, AccountNumberLength))
            {
                if (accountLengthChecker.CheckIfStringIsSpecificLength(accountNumber, AcountNumberFirstCaseLenght))
                {
                    if (!accountEndChecker.CheckIfStringEndsWihtSpecifiedCharacter(accountNumber, AcountNumberSpecialCharacter)) return false;
                    return true;
                }
                return false;
            }

            return true;
        }
    }
}
