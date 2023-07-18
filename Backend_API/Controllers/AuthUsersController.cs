using Backend.Services;
using Backend.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Backend.Data;

namespace Backend_API.Controllers
{
    public class AuthUsersController : BaseController
    {
        private readonly PaymentContext _db;
        private readonly AuthService _auth;

        public AuthUsersController(PaymentContext db, AuthService auth)
        {
            _auth = auth;
            _db = db;
        }

        [HttpPost]
        public ActionResult<AuthResponse> AuthLogin(AuthRequest request)
        {
            var response = new AuthResponse();

            var user = _db.Users.Where(user => user.user_email == request.email).SingleOrDefault();
            if (user == null)
            {
                response.Message = "Username was invaild";
                return response;
            }

            var passwordcorrect = user.user_password == request.password;
            if (passwordcorrect)
            {
                response.Message = "Password was invaild";
                return response;
            }

            var personalToken = _auth.GenerateToken(user.user_email);
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
