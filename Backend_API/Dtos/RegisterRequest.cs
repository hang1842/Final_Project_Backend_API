namespace Backend.Dtos
{
    public class RegisterRequest
    {
        public string UserName { get; set; } = default!;
        public string UserType { get; set; }= default!;
        public string email { get; set; }=default!;
        public string password { get; set; } = default!;
        public float? Balance { get; set; }

        public RegisterRequest(string userName, string userType, string email, string password, float? balance)
        {
            UserName = userName;
            UserType = userType;
            this.email = email;
            this.password = password;
            Balance = balance;
        }
    }
}
