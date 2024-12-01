namespace AccountValidator.Services.validations
{
    public class EndsWithSpecifiedCharacter
    {
        public bool CheckIfStringEndsWihtSpecifiedCharacter(string line, char specialCharacter)
        {
            if (line[^1] == specialCharacter)
            {
                return true;
            }
            return false;
        }
    }
}
