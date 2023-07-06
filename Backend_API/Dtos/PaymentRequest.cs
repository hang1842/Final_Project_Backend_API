namespace Backend.Dtos
{
    public class PaymentRequest
    {
        public int personalId { get; set; }=default!;
        public int merchantId { get; set; }= default!;
        public float? amount { get; set; }
        public bool status { get; set; } = false;
    }
}
