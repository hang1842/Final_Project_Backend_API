namespace Backend.Dtos
{
    public class ConfirmGetResponse
    {
        public int PaymentId { get; set; }
        public string PerEmail { get; set; } = default!;
        public string MerEmail { get; set; } = default!;
        public float? Amount { get; set; }
        public string Message { get; set; }

        public ConfirmGetResponse(int paymentId, string perEmail, string merEmail, float? amount)
        {
            PaymentId = paymentId;
            PerEmail = perEmail;
            MerEmail = merEmail;
            Amount = amount;
        }

        public ConfirmGetResponse(string message)
        {
            Message = message;
        }

        public ConfirmGetResponse()
        {
        }
    }
}
