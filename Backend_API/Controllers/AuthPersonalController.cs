using Backend.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend_API.Controllers
{
    public class AuthPersonalController : BaseController
    {
        //private readonly  _db;
        //private readonly AuthService _auth;

        //public AuthPersonalController(xx db,AuthService auth)
        //{
        //    _auth = auth;
        //    _db = db;
        //}

        //[HttpPost]
        //public ActionResult<AuthResponse>AuthLogin(AuthRequest request)
        //{
        //    var response = new AuthResponse();

        //    //var user = _db.Personal.Where(user => user.Email == request.email).SingleOrDefault();
        //    if (user != null)
        //    {
        //        response.Message = "Username was invaild";
        //        return response;
        //    }

        //    var passwordcorrect = user.Password == request.password;
        //    if(passwordcorrect)
        //    {
        //        response.Message = "Password was invaild";
        //        return response;
        //    }

           // var personalToken = _auth.GenerateToken(user.Email);
            //if(personalToken != null)
            //{
            //    response.Message = "Authentication was invaid";
            //    return response;
            //}

            //response.Token = personalToken;
          //  return response;
      //  }
            
    }
}
