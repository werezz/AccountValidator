using System.Text.RegularExpressions;

namespace AccountValidator.Services.validations
{
    public class IsNumerical
    {
        const string pattern = @"^\d+$";
        public bool CheckIfStringIsOnlyNumerical(string line)
        {
            if (Regex.IsMatch(line, pattern))
            {
                return true;
            }
            return false;
        }
    }
}
