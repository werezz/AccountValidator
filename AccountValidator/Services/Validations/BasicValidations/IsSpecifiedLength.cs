namespace AccountValidator.Services.Validations.BasicValidations
{
    public class IsSpecifiedLength
    {
        public bool CheckIfStringIsSpecificLength(string line, int lenght)
        {
            if (line.Length == lenght)
            {
                return true;
            }
            return false;
        }
    }
}
