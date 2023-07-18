namespace Backend.Dtos
{
    public class BalanceResponse
    {
        public BalanceResponse()
        {
        }

        public decimal? balance { get; set; }
        public string message { get; set; }

        public BalanceResponse(decimal? balance)
        {
            this.balance = balance;
        }

        public BalanceResponse(string message)
        {
            this.message = message;
        }
    }
}
