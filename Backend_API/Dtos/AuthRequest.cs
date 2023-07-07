namespace Backend.Dtos
{
    public class AuthRequest
    {
        public string email { get; set; } = default!;
        public string password { get; set; }=default!;

        public AuthRequest(string email, string password)
        {
            this.email = email;
            this.password = password;
        }
    }
}
