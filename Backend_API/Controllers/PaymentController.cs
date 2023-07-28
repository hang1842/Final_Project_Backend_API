using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using Backend.Services;
using Backend.Data;
using Backend.Dtos;
using Backend.Models;

namespace Backend_API.Controllers
{
    public class PaymentController : BaseController
    {
        private readonly AuthService _auth;
        private readonly PaymentContext _db;
        private readonly IHttpClientFactory _http;

        public PaymentController(AuthService auth, PaymentContext db, IHttpClientFactory http)
        {
            _auth = auth;
            _db = db;
            _http = http;
        }

        [HttpPost]
        public ActionResult<PaymentResponse> NewPayment(PaymentRequest request)
        {
            var response = new PaymentResponse();
            var payment = new Payments(0,request.perEmail, request.merEmail, request.amount,
                request.payment_method, DateTime.Now, null, 0);
            _db.Payments.Add(payment);
            _db.SaveChanges();

            var user = _db.Users.Find(request.perEmail);

            if (user == null)
            {
                response.Message = "User was invalid";
                return response;
            }

            if (user.user_pin != request.pin)
            {
                response.Message = "Pin number was invalid";
                return response;
            }

            if (user.balance < request.amount)
            {
                response.Message = "Your Local Balance is not enough!";
                return response;
            }

            if(request.payment_method == "Stripe")
            {
                var client = _http.CreateClient();
                var stripe = client.GetAsync("https://Backend_API/api/stripe");
                response.Message= stripe.Result.ToString();
                return response;
            }

            Processor(request.perEmail, request.merEmail, request.amount);
            response.Message = "The payment has been paid";
            return response;
        }

        [HttpPut]
        public ActionResult<PaymentResponse> ConfirmPayment(string id)
        {
            var response = new PaymentResponse();
            var ExistingPayment = _db.Payments.Find(id);

            if (ExistingPayment != null) 
            {
                ExistingPayment.Status = 1;
                ExistingPayment.PaidDate= DateTime.Now;
                _db.SaveChanges();
            }

            Processor(ExistingPayment.PerEmail,ExistingPayment.MchEmail,ExistingPayment.Amount);

            response.Message = $"The Payment {id} has been confirmed and closed the deal.";
            return response;
        }


        [NonAction]
        private void Processor(string perEmail, string mchEmail, decimal? amount)
        {
            var personals = _db.Users.Where(per=>per.user_email==perEmail).SingleOrDefault();
            var merchants = _db.Users.Where(mer=>mer.user_email==mchEmail).SingleOrDefault();

            if(personals!=null && merchants!=null)
            {
                personals.balance -= amount;
                merchants.balance += amount;
                _db.SaveChanges();
            }
        }

      

    }
}
