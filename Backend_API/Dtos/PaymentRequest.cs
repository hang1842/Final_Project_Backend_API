namespace Backend.Dtos
{
    public class PaymentRequest
    {
        public string perEmail { get; set; }=default!;
        public string merEmail { get; set; }= default!;
        public decimal? amount { get; set; }
        public bool status { get; set; } = false;

        public PaymentRequest(string perEmail, string merEmail, decimal? amount, bool status)
        {
            this.perEmail = perEmail;
            this.merEmail = merEmail;
            this.amount = amount;
            this.status = status;
        }

        public PaymentRequest()
        {
        }
    }
}
