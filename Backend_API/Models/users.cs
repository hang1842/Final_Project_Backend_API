using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using IndexAttribute = Microsoft.EntityFrameworkCore.IndexAttribute;

namespace Backend.Models
{
    [Index("user_email", IsUnique = true)]
    public class Users
    {
        public int user_Id { get; set; }
        public string user_name { get; set; } = default!;
        public string user_email { get; set; } = default!;
        public string user_password { get; set; } = default!;
        public string user_category { get; set; } = default!;
        public decimal? balance { get; set; }
        public int user_pin { get; set; } = default!;  
        public List<Cards> cards { get; set; }
        public List<Payments> payments { get; set; }

        public Users(int user_Id, string user_name, string user_email, 
            string user_password, string user_category, int user_pin,decimal? balance)
        {
            this.user_Id = user_Id;
            this.user_name = user_name;
            this.user_email = user_email;
            this.user_password = user_password;
            this.user_category = user_category;
            this.user_pin = user_pin;
            this.balance = balance;
        }

        public static string HashString(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = sha256.ComputeHash(inputBytes);
                return Convert.ToBase64String(hashBytes);
            }
        }
    }
}
