using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace Backend_API.Models
{
    [Index("card_number",IsUnique=true)]
    public class Cards
    {
        public int card_Id { get; set; }
        public string card_bank { get; set; } = default!;
        public string card_number { get; set; } = default!;
        public string card_type { get; set; } = default!;
        public decimal? card_balance { get; set; }
        public int user_Id { get; set; }
        public Users? users { get; set; }

        public Cards (int card_Id, string card_bank, string card_number, string card_type, 
            decimal? card_balance,int user_Id)
        {
            this.card_Id = card_Id;
            this.card_bank = card_bank;
            this.card_number = card_number;
            this.card_type = card_type;
            this.card_balance = card_balance;
            this.user_Id = user_Id;
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
