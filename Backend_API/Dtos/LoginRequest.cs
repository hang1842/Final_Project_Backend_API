namespace Backend.Dtos
{
    public class LoginRequest
    {
        public string email { get; set; } = default!;
        public string password { get; set; }=default!;

        public LoginRequest(string email, string password)
        {
            this.email = email;
            this.password = password;
        }
    }
}
