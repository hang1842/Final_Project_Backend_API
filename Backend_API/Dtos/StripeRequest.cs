using Backend_API.Models;

namespace Backend.Dtos
{
    public class StripeRequest
    {
        public StripeRequest()
        {
        }

        public string PerEmail { get; set; } = default!;
        public string MchEmail { get; set; } = default!;
        public decimal? Amount { get; set; }
        public int Status { get; set; } = 0;

        public StripeRequest(string perEmail, string mchEmail, decimal? amount,int status)
        {
            PerEmail = perEmail;
            MchEmail = mchEmail;
            Amount = amount;
            Status = status;
        }
    }
}
