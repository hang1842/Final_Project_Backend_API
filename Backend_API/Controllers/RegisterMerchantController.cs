using Backend.Dtos;
using Backend_API.Data;
using Backend_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Backend_API.Controllers
{
    public class RegisterMerchantController : BaseController
    {
        //const string connectionString = "Server=localhost;Database=payment;Uid=root;Pwd=;";
        //private static MySqlConnection connection = new MySqlConnection(connectionString);
        private readonly PaymentContext _db;

        public RegisterMerchantController(PaymentContext db)
        {
            _db = db;
        }

        [HttpPost]
        public ActionResult<RegisterResponse> AddNewMerchant(merchants mer)
        {
            var response = new RegisterResponse();

            //string insertString = $"insert into `personal` (`per_name`,`per_email`,`per_password`,`per_balance`)" +
            //        $" values('{mer.MerName}','{mer.email}','{mer.password}','{mer.Balance}');";
            //MySqlCommand command = new MySqlCommand(insertString, connection);
            //command.ExecuteNonQuery();
            _db.Merchants.Add(mer);
            _db.SaveChanges();

            response.Message = $"{mer.MchName} has been added to Database successfully.";
            return response;
        }

        [HttpPut]
        public ActionResult<RegisterResponse> UpdateMerchant(int id,RegisterMerchantRequest updateMer)
        {
            var response = new RegisterResponse();

            var existingEntity = _db.Merchants.Find(id);
            if (existingEntity != null)
            {
                existingEntity.MchBalance = updateMer.Balance;
            }
            _db.SaveChanges();

            response.Message = $"{updateMer.MerName} has been updated successfully.";
            return response;
        }
    }
}
