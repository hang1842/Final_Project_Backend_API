using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using IndexAttribute = Microsoft.EntityFrameworkCore.IndexAttribute;

namespace Backend_API.Models
{
    [Index("PerEmail", IsUnique = true)]
    public class Personals
    {
        public int PerId { get; set; }
        public string PerName { get; set; } = default!;
        public string PerEmail { get; set; } = default!;
        public string PerPassword { get; set; } = default!;
        public float? PerBalance { get; set; }

        public List<Payments> Payments { get; set; }

        public Personals(int perId, string perName, string perEmail, string perPassword, float? perBalance)
        {
            PerId = perId;
            PerName = perName;
            PerEmail = perEmail;
            PerPassword = perPassword;
            PerBalance = perBalance;
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
