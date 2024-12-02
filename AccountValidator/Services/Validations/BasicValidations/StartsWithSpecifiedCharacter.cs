namespace AccountValidator.Services.Validations.BasicValidations
{
    public class StartsWithSpecifiedCharacter
    {
        public bool CheckIfStringStartsWihtSpecifiedCharacter(string line, char character)
        {
            if (line.First() == character)
            {
                return true;
            }
            return false;
        }
    }
}
