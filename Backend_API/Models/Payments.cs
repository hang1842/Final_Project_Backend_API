using System.Security.Cryptography;
using System.Text;

namespace Backend_API.Models
{
    public class Payments
    {
        public int PaymentId { get; set; }
        public string PerEmail { get; set; } = default!;
        public string MchEmail { get; set; } = default!;
        public Personals? personal { get; set; }
        public Merchants? merchants { get; set; }
        public float? Amount { get; set; }
        public DateTime CreateDate { get; set; }

        public DateTime? PaidDate { get; set; }

        public bool Status { get; set; }

        public Payments(int paymentId, string perEmail, string mchEmail, float? amount, 
            DateTime createDate, DateTime? paidDate, bool status)
        {
            PaymentId = paymentId;
            PerEmail = perEmail;
            MchEmail = mchEmail;
            Amount = amount;
            CreateDate = createDate;
            PaidDate = paidDate;
            Status = status;
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
