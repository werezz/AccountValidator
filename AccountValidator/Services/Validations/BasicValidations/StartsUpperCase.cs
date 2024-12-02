using System.Text.RegularExpressions;

public class StartsUpperCase
{
    const string pattern = @"^[A-Z].*";

    public bool CheckIfStartsUpperCase(string line)
    {
        if (Regex.IsMatch(line, pattern))
        {
            return true;
        }

        return false;
    }
}
