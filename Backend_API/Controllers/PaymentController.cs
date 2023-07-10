using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using Backend.Services;
using Backend_API.Data;
using Backend.Dtos;

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
            _db.Payments.Add(request);
            _db.SaveChanges();

            response.Message = "A new Payment has been added.";
            return response;
        }
        [HttpPut]
        public ActionResult<PaymentResponse> UpdatePayment(int id, PaymentRequest request)
        {
            var response = new PaymentResponse();
            var ExistingPayment = _db.Payments.Find(id);
            if (ExistingPayment != null) 
            {
                ExistingPayment.Status = true;
                ExistingPayment.PaidDate= DateTime.Now;
            }
            response.Message = $"The Payment {id} has been confirmed by {request.personalId}";
            return response;
        }
    }
}
