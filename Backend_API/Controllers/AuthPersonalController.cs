using Backend.Services;
using Backend.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Backend_API.Data;

namespace Backend_API.Controllers
{
    public class AuthPersonalController : BaseController
    {
        private readonly PaymentContext _db;
        private readonly AuthService _auth;

        public AuthPersonalController(PaymentContext db, AuthService auth)
        {
            _auth = auth;
            _db = db;
        }

        [HttpPost]
        public ActionResult<AuthResponse> AuthLogin(AuthRequest request)
        {
            var response = new AuthResponse();

            var user = _db.Personals.Where(user => user.PerEmail == request.email).SingleOrDefault();
            if (user == null)
            {
                response.Message = "Username was invaild";
                return response;
            }

            var passwordcorrect = user.PerPassword == request.password;
            if (passwordcorrect)
            {
                response.Message = "Password was invaild";
                return response;
            }

            var personalToken = _auth.GenerateToken(user.PerEmail);
            if (personalToken != null)
            {
                response.Message = "Authentication was invaid";
                return response;
            }

            response.Token = personalToken;
            return response;
        }

    }
}
