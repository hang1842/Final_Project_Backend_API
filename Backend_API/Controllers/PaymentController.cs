using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using Backend.Services;
using Backend_API.Data;
using Backend.Dtos;
using Backend_API.Models;

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
            var payment = new payments(0, request.perEmail, request.merEmail, request.amount, DateTime.Now, null, 0);
            _db.Payments.Add(payment);
            _db.SaveChanges();

            response.Message = "A new Payment has been added.";
            return response;
        }
        [HttpPut]
        public ActionResult<PaymentResponse> UpdatePayment(int id)
        {
            var response = new PaymentResponse();
            var ExistingPayment = _db.Payments.Find(id);
            if (ExistingPayment != null) 
            {
                ExistingPayment.Status = 1;
                ExistingPayment.PaidDate= DateTime.Now;
            }
            response.Message = $"The Payment {id} has been confirmed.";
            return response;
        }
    }
}
