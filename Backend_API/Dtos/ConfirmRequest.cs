namespace Backend.Dtos
{
    public class ConfirmRequest
    {
        public string paymentId { get; set; }
        public int pin { get; set; }
        public ConfirmRequest(string paymentId, int pin)
        {
            this.paymentId = paymentId;
            this.pin = pin;
        }
    }
}
