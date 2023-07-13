namespace Backend.Dtos
{
    public class StripeResponse
    {
        public string? SessionId { get; set; }
        public string? PublicKey { get; set; }

        public StripeResponse(string? sessionId, string? publicKey)
        {
            SessionId = sessionId;
            PublicKey = publicKey;
        }
    }
}
