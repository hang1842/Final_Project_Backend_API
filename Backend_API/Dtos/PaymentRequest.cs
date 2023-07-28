using Backend.Models;

namespace Backend.Dtos
{
    public class PaymentRequest
    {
        public string perEmail { get; set; }=default!;
        public string merEmail { get; set; }= default!;
        public decimal? amount { get; set; }
        public string payment_method { get; set; } = default!;
        public int pin { get; set; }
        public int status { get; set; } = 0;
        public PaymentRequest(string perEmail, string merEmail, decimal? amount, 
            string payment_method,int pin, int status)
        {
            this.perEmail = perEmail;
            this.merEmail = merEmail;
            this.amount = amount;
            this.payment_method = payment_method;
            this.pin = pin;
            this.status = status;
        }

        public PaymentRequest()
        {
        }
    }
}
