namespace AccountValidator.Models
{
    public class Response
    {
        public Response() { }

        public bool FileValid { get; set; }
        public List<string> InvalidLines { get; set; }
    }
}
