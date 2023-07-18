namespace Backend.Dtos
{
    public class BalanceRequest
    {
        public string user_email { get; set; } = default!;

        public BalanceRequest(string user_email)
        {
            this.user_email = user_email;
        }
    }
}
