using Backend_API.Models;
using Microsoft.EntityFrameworkCore;


namespace Backend_API.Data
{
    public class PaymentContext:DbContext
    {
        public PaymentContext(DbContextOptions<PaymentContext> options)
       : base(options)
        {
        }

        public DbSet<merchants> Merchants { get; set; }
        public DbSet<payments> Payments { get; set; }
        public DbSet<personals> Personals { get; set; }

    }
}
