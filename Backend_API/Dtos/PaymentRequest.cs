namespace Backend.Dtos
{
    public class PaymentRequest
    {
        public int perEmail { get; set; }=default!;
        public int merEmail { get; set; }= default!;
        public float? amount { get; set; }
        public bool status { get; set; } = false;
    }
}
