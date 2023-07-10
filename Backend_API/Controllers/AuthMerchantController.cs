using Backend.Dtos;
using Backend_API.Data;
using Backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Backend_API.Controllers
{
    public class AuthMerchantController : BaseController
    {
        private readonly PaymentContext _db;
        private readonly AuthService _auth;
        
        public AuthMerchantController(PaymentContext db, AuthService auth)
        {
            _db = db;
            _auth = auth;
        }

        [HttpPost]
        public ActionResult<AuthResponse> Login([FromBody] AuthRequest request)
        { 
            var response = new AuthResponse();
            var users = _db.Merchants.Where(user => user.MchEmail == request.email).SingleOrDefault();
            if (users == null)
            {
                response.Message = "Username was invaild";
                return response;
            }

            var passwordIsCorrect = users.MchPassword == request.password;
            if(!passwordIsCorrect)
            {
                response.Message = "Password was invalid";
                return response;
            }
            var Token = _auth.GenerateToken(request.email);
            if(Token == null)
            {
                response.Message = "Token was invalid";
                return response;
            }
            response.Token = Token;
            return response;
        }
    }
}
