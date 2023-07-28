using Backend.Models;

namespace Backend.Dtos
{
    public class PaymentsDto
    {
        public string perEmail { get; set; } = default!;
        public string merEmail { get; set; } = default!;
        public decimal? amount { get; set; }
        public string payment_method { get; set; } = default!;
        public DateTime? CreateDate { get; set; }
        public DateTime? PaidDate { get; set; }
        public int status { get; set; } = 0;
        public PaymentsDto(Payments pay)
        {
            perEmail = pay.PerEmail;
            merEmail = pay.MchEmail;
            amount = pay.Amount;
            payment_method = pay.payment_method;
            CreateDate = pay.CreateDate;
            PaidDate = pay.PaidDate;
            status = pay.Status;
        }

        public PaymentsDto(string perEmail, string merEmail, decimal? amount, string payment_method, 
            DateTime? createDate, DateTime? paidDate, int status)
        {
            this.perEmail = perEmail;
            this.merEmail = merEmail;
            this.amount = amount;
            this.payment_method = payment_method;
            CreateDate = createDate;
            PaidDate = paidDate;
            this.status = status;
        }
    }
}
