
namespace AccountValidator.DTOs
{
    public record ValidationResultDTO
    {
        public bool FileValid { get; set; }

        public List<string>? InvalidLines { get; set; }

        public ValidationResultDTO(bool fileValid, List<string> invalidLines) 
        {
            FileValid = fileValid;
            InvalidLines = invalidLines;
        }
    }
}
