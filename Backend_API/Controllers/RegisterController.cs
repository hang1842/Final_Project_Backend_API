using Backend.Dtos;
using Backend_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using Backend_API.Data;
using Backend.Services;

namespace Backend_API.Controllers
{
    public class RegisterController : BaseController
    {
        private readonly PaymentContext _db;
        private readonly AuthService _auth;

        public RegisterController(PaymentContext db, AuthService auth)
        {
            _db = db;
            _auth = auth;
        }

        [HttpPost]
        public ActionResult<RegisterResponse> AddNewMember(RegisterRequest request)
        {
            var response = new RegisterResponse();

            var personal = new Users(0,request.user_name, request.user_email, request.user_password,request.user_category);
            _db.SaveChanges();

            response.Message = $"{request.user_name} has been added to Database successfully.";
            return response;
        }
    }
}
