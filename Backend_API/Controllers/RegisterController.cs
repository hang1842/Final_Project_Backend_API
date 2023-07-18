using Backend.Dtos;
using Backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using Backend.Data;
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

            var personal = new Users(0,request.user_name, request.user_email, request.user_password, request.user_category, request.user_pin,0);
            _db.SaveChanges();

            response.Message = $"{request.user_name} has been added to Database successfully.";
            return response;
        }

        [HttpPut]
        public  ActionResult<RechargeResponse> RechargeBalance(RechargeRequest request)
        {
            var response = new RechargeResponse();

            var ExistingUsers = _db.Users.Where(user => user.user_email == request.email).SingleOrDefault();

            if (ExistingUsers == null) 
            {
                response.message = "username war invaild";
                return response;
            }

            ExistingUsers.balance = request.recharge;
            _db.SaveChanges();
            response.message = $"Successfully recharged ${request.recharge}";
            return response;
        }
    }
}
