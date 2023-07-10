using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace Backend_API.Models
{
    [Index("MchEmail",IsUnique=true)]
    public class merchants
    {
        public int MchId { get; set; }
        public string MchName { get; set; } = default!;
        public string MchEmail { get; set; } = default!;
        public string MchPassword { get; set; } = default!;
        public float? MchBalance { get; set; }
        public List<payments> payments { get; set; }

        public merchants(int mchId, string mchName, string mchEmail, string mchPassword, float? mchBalance)
        {
            MchId = mchId;
            MchName = mchName;
            MchEmail = mchEmail;
            MchPassword = mchPassword;
            MchBalance = mchBalance;
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
