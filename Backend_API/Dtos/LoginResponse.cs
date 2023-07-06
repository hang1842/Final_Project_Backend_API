namespace Backend.Dtos
{
    public class LoginResponse
    {
        public string? Message { get; set; }

        public LoginResponse(string? message)
        {
            Message = message;
        }
    }
}
