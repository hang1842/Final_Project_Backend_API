namespace Backend.Dtos
{
    public class AuthResponse
    {
        public string? Message { get; set; }
        public string? Token { get; set; }

        public AuthResponse()
        {
        }
    }
}
