namespace Backend.Dtos
{
    public class RechargeRequest
    {
        public string email { get; set; } = default!;
        public decimal recharge { get; set; } = default!;

        public RechargeRequest(string email, decimal recharge)
        {
            this.email = email;
            this.recharge = recharge;
        }
    }
}
