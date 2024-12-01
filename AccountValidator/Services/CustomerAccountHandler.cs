using AccountValidator.Models;
using AccountValidator.Services.Interfaces;
using System.Diagnostics;
using System.Text;

namespace AccountValidator.Services
{
    public class CustomerAccountHandler: ICustomerAccountHandler
    {
        private readonly IAccountNameValidator _accountNameValidator;
        private readonly IAccountNumberValidator _accountNumberValidator;
        private readonly ILogger<CustomerAccountHandler> _logger;
        public CustomerAccountHandler(IAccountNameValidator accountNameValidator, IAccountNumberValidator accountNumberValidator, ILogger<CustomerAccountHandler> logger)
        {
            _accountNameValidator = accountNameValidator;
            _accountNumberValidator = accountNumberValidator;
            _logger = logger;
        }

        public Response ValidateAccount(Request request)
        {
            var result = new Response();
            result.FileValid = true;
            result.InvalidLines = new List<string>();
            StringBuilder errorBuilder = new StringBuilder();
            Stopwatch stopwatch = new Stopwatch();

            for (int i = 0; i <= request.Accounts.Count - 1; i++)
            {
                stopwatch.Start();

                if (!_accountNameValidator.ValidateAccountName(request.Accounts[i].Name)) errorBuilder.Append("account name, ");
                if (!_accountNumberValidator.ValidateAccountNumber(request.Accounts[i].Number)) errorBuilder.Append("account number, ");

                result.InvalidLines.Add(InvalidLineMessageBuilder(errorBuilder,request.Accounts[i].Name, request.Accounts[i].Number, request.Accounts[i].LineNumber));

                stopwatch.Stop();
                _logger.LogInformation("line {LineNumber} validated in: {ElapsedTime}", request.Accounts[i].LineNumber, stopwatch.Elapsed);
                stopwatch.Reset();

                errorBuilder.Clear();
            };

            result.InvalidLines.RemoveAll(s => s.Length == 0);
            if (result.InvalidLines.Count > 0) result.FileValid = false;

            return result;
        }

        private static string InvalidLineMessageBuilder(StringBuilder message, string accountName, string accountNumber, int lineNumber)
        {
            if (string.IsNullOrEmpty(message.ToString())) return "";

            var formattedMessage = FormatErrorMessage(message.ToString());
            message.Clear();
            message.Append(formattedMessage);
            if (accountName == " " && accountNumber == " ")
            {
                message.Append($" -not valid for line {lineNumber} missing AccountNumber or AccountName");
            }
            else
            {
                message.Append($" -not valid for line {lineNumber} '{accountName} {accountNumber}'");
            }
            return message.ToString();
        }

        private static string FormatErrorMessage(string errorMessage)
        {
            errorMessage = char.ToUpper(errorMessage[0]) + errorMessage.Substring(1); ;
            errorMessage = errorMessage.Remove(errorMessage.Length - 2);
            return errorMessage;
        }
    }
}
