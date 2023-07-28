using Backend.Models;

namespace Backend.Dtos
{
    public class RegisterRequest
    {
        public string user_name { get; set; } = default!;
        public string user_email { get; set; }=default!;
        public string user_password { get; set; } = default!;
        public string user_category { get; set; } = "Personal";
        public int user_pin { get; set; }

        public RegisterRequest(string user_name, string user_email,
            string user_password, string user_category, int user_pin)
        {
            this.user_name = user_name;
            this.user_email = user_email;
            this.user_password = user_password;
            this.user_category = user_category;
            this.user_pin = user_pin;
        }

        public RegisterRequest()
        {
        }
    }
}
