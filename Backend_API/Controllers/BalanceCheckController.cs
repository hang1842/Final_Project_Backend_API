using Backend_API.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using Backend.Dtos;
using Backend_API.Dtos;

namespace Backend_API.Controllers
{
    public class BalanceCheckController : BaseController
    {
        private readonly PaymentContext _db;
        

        public BalanceCheckController(PaymentContext db)
        {
            _db = db;           
        }
        [HttpPost]
        public ActionResult<BalanceResponse> BalanceResponse([FromBody]BalanceRequest request)
        {
            var response = new BalanceResponse();

            var users = _db.Users.Where(user => user.user_email == request.user_email).SingleOrDefault();

            if (users == null)
            {
                response.message = "User name was invaild";
                return response;
            }

            response.balance = users.balance;
            return response;
        }
    }

}
