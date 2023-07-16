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
    public class RegisterPersonalController : BaseController
    {
        private readonly PaymentContext _db;
        private readonly AuthService _auth;

        public RegisterPersonalController(PaymentContext db, AuthService auth)
        {
            _db = db;
            _auth = auth;
        }

        [HttpPost]
        public ActionResult<RegisterResponse> AddNewMember(RegisterPersonalRequest per)
        {
            var response = new RegisterResponse();

            var personal = new users(0, per.PerName, per.email, per.password, per.Balance);
            _db.Personals.Add(personal);
            _db.SaveChanges();

            response.Message = $"{per.PerName} has been added to Database successfully.";
            return response;
        }
    }
}
