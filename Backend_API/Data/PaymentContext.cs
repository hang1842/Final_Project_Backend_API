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

        public DbSet<Cards> Cards { get; set; }
        public DbSet<Payments> Payments { get; set; }
        public DbSet<Users> Users{ get; set; }

    }
}
