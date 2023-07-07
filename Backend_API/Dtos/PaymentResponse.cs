namespace Backend.Dtos
{
    public class PaymentResponse
    {
        public string? Message { get; set; }

        public PaymentResponse(string? message)
        {
            Message = message;
        }
    }
}
