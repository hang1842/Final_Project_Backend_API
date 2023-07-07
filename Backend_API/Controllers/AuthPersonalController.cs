using Backend.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend_API.Controllers
{
    public class AuthController : BaseController
    {
        private readonly  _db;

        public AuthController( db)
        {
            _db = db;
        }

        [HttpPost]
        public ActionResult<LoginResponse>AuthLogin(LoginRequest request)
        {
            var response = new LoginResponse();

            var user = _db.Personal.Where(user => user.Email == request.email).SingleOrDefault();
        }
            
    }
}
