﻿using System.Text.RegularExpressions;

namespace AccountValidator.Services.validations
{
    public class IsAlphaBetic
    {
        const string pattern = @"^[A-Za-z]+$";
        public bool CheckIfStringIsAlphabetic(string line)
        {
            if (Regex.IsMatch(line, pattern))
            {
                return true;
            }
            return false;
        }
    }
}
