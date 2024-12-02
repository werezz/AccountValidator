using AccountValidator.Models;
using AccountValidator.Services.Interfaces;
using System.Text;

namespace AccountValidator.Services
{
    public class CustomerAccountUploadHandler: ICustomerAccountUploadHandler
    {
        private readonly ILogger<CustomerAccountUploadHandler> _logger;

        public CustomerAccountUploadHandler( ILogger<CustomerAccountUploadHandler> logger)
        {
            _logger = logger;
        }

        public Request Upload(IFormFile file)
        {
            var accounts = new Request();
            accounts.Accounts = new List<Account>();

            using (var memoryStream = new MemoryStream())
            {
                file.CopyTo(memoryStream);

                memoryStream.Position = 0;
                try
                {
                    using (var reader = new StreamReader(memoryStream, Encoding.UTF8))
                    {
                        var counter = 1;

                        while (!reader.EndOfStream)
                        {
                            var line = reader.ReadLine();
                            if (!string.IsNullOrWhiteSpace(line))
                            {
                                var parts = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                                if (parts.Length < 2) 
                                { 
                                    accounts.Accounts.Add(new Account { Name = " ", Number = " ", LineNumber = counter }); 
                                }
                                else
                                {
                                    accounts.Accounts.Add(new Account { Name = parts[0], Number = parts[1], LineNumber = counter });
                                }
                            }
                            counter++;
                        }
                        return accounts;
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError("An error occurred while parsing the file {Exeption}", ex);
                    throw;
                }
            }
        }

        public bool CheckIfFileIsNullOrEmpty(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return true;
            }
            return false;
        }
    }
}
