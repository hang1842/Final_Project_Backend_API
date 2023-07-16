using Backend_API.Models;

namespace Backend.Dtos
{
    public class RegisterPersonalRequest
    {
        public string PerName { get; set; } = default!;
        public string email { get; set; }=default!;
        public string password { get; set; } = default!;
        public float? Balance { get; set; }

        public RegisterPersonalRequest(Users per)
        {
            PerName = per.PerName;
            email = per.PerEmail;
            password=per.PerPassword;
            Balance = per.PerBalance;
        }
    }
}
