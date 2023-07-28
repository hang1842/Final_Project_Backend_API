using Backend.Models;
using Microsoft.EntityFrameworkCore;
using Backend.Dtos;


namespace Backend.Data
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
