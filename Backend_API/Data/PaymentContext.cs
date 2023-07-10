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

        public DbSet<Merchants> Merchants { get; set; }
        public DbSet<Payments> Payments { get; set; }
        public DbSet<Personals> Personals { get; set; }

    }
}
