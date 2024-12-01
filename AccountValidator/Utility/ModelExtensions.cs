using AccountValidator.DTOs;
using AccountValidator.Models;

namespace AccountValidator.Utility
{
    public static class ModelExtensions
    {
        public static ValidationResultDTO ToValidationResultDTO(this Response validationResult)
        {
            return new ValidationResultDTO(validationResult.FileValid, validationResult.InvalidLines);
        }
    }
}
