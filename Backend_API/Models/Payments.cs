using System.Security.Cryptography;
using System.Text;

namespace Backend_API.Models
{
    public class Payments
    {
        public int PaymentId { get; set; }
        public string PerEmail { get; set; } = default!;
        public string MchEmail { get; set; } = default!;
        public Users? personal { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? CreateDate { get; set; }

        public DateTime? PaidDate { get; set; }

        public int Status { get; set; } = 0;

        public Payments(int paymentId, string perEmail, string mchEmail, decimal? amount, 
            DateTime createDate, DateTime? paidDate, int status)
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
