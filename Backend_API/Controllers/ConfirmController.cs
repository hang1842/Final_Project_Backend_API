using Backend.Dtos;
using Backend.Services;
using Backend_API.Data;
using Backend_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend_API.Controllers
{
    public class ConfirmController : BaseController
    {
        private readonly PaymentContext _db;
        private readonly AuthService _auth;

        public ConfirmController(PaymentContext db, AuthService auth)
        {
            _db = db;
            _auth = auth;
        }
        [HttpGet]
        public ActionResult<ConfirmGetResponse> SendConfirm(string PerEmail)
        {
            var response = new ConfirmGetResponse();
            var lastest = _db.Payments.Where(payment=>payment.PerEmail==PerEmail)
                .OrderByDescending(payment=>payment.CreateDate).SingleOrDefault();

            if(lastest == null) 
            {
                 response = new ConfirmGetResponse("Payment was invalid");
                return response;
            }
             response = new ConfirmGetResponse(lastest.PaymentId, lastest.PerEmail, lastest.MchEmail, lastest.Amount);
            return response;
        }

    }
}
