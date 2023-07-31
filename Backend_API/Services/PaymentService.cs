using Backend.Data;
using Backend.Dtos;
using Backend.Models;
using Backend_API.Controllers;
using Org.BouncyCastle.Asn1.Ocsp;

namespace Backend.Services

{
    public class PaymentService
    {
        private readonly PaymentContext _db;
        private readonly IServiceProvider sp;
        private static StripeController stripeController;

        public PaymentService(PaymentContext db, IServiceProvider sp)
        {
            _db = db;
            this.sp = sp;
        }

        public bool ProcessPayment(PaymentRequest request)
        {
            // Check the local balance
            decimal? localBalance = GetLocalBalance(request.perEmail);
            bool success = true;
            

            if (localBalance >= request.amount && request.payment_method=="Local Balance")
            {
                // Process the payment using the local balance
                ProcessInLocalBalance(request.perEmail,request.merEmail,request.amount);
                return success;
            }
            else
            {
                // Call the StripeController to process the payment using the Stripe API
                StripeRequest stRequest = new StripeRequest(request.perEmail,request.merEmail,request.amount,request.status);
                stripeController.StripeResponse(stRequest, sp);    
                return success; 
            }
        }

        private decimal? GetLocalBalance(string perEmail)
        {
            var user = _db.Users.Find(perEmail);
            var localbalance = user.balance;
            return localbalance;
        }

        private void ProcessInLocalBalance(string perEmail, string mchEmail, decimal? amount)
        {
            var personals = _db.Users.Where(per => per.user_email == perEmail).SingleOrDefault();
            var merchants = _db.Users.Where(mer => mer.user_email == mchEmail).SingleOrDefault();

            if (personals != null && merchants != null)
            {
                personals.balance -= amount;
                merchants.balance += amount;
                _db.SaveChanges();
            }
        }
    





    }
}
