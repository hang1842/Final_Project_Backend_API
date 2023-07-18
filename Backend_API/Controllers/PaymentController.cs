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

        public PaymentController(AuthService auth, PaymentContext db)
        {
            _auth = auth;
            _db = db;
        }
        [HttpPost]
        public ActionResult<PaymentResponse> NewPayment(PaymentRequest request)
        {
            var response = new PaymentResponse();
            var payment = new Payments(0, request.perEmail, request.merEmail, request.amount,request.payment_method, DateTime.Now, null, 0);
            _db.Payments.Add(payment);
            _db.SaveChanges();

            response.Message = "A new Payment has been added.";
            return response;
        }

        [HttpGet]
        public ActionResult<ConfirmResponse> SendConfirm(string PerEmail)
        {
            var response = new ConfirmResponse();
            var lastestpayment = _db.Payments.Where(payment => payment.PerEmail == PerEmail)
                .OrderByDescending(payment => payment.CreateDate).SingleOrDefault();

            if (lastestpayment == null)
            {
                response = new ConfirmResponse("Payment was invalid");
                return response;
            }
            response = new ConfirmResponse(lastestpayment.PaymentId, lastestpayment.PerEmail,
                lastestpayment.MchEmail, lastestpayment.Amount);
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
