namespace Backend.Dtos
{
    public class ConfirmResponse
    {
        public int PaymentId { get; set; }
        public string PerEmail { get; set; } = default!;
        public string MerEmail { get; set; } = default!;
        public decimal? Amount { get; set; }
        public string Message { get; set; }

        public ConfirmResponse(int paymentId, string perEmail, string merEmail, decimal? amount)
        {
            PaymentId = paymentId;
            PerEmail = perEmail;
            MerEmail = merEmail;
            Amount = amount;
        }

        public ConfirmResponse(string message)
        {
            Message = message;
        }

        public ConfirmResponse()
        {
        }
    }
}
