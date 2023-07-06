using Backend.Dtos;
using Backend_API.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Backend_API.Controllers
{
    public class RegisterMerchantController : BaseController
    {
        const string connectionString = "Server=localhost;Database=payment;Uid=root;Pwd=;";
        private static MySqlConnection connection = new MySqlConnection(connectionString);


        [HttpPost]
        public ActionResult<RegisterResponse> AddNewMerchant(RegisterMerchantRequest mer)
        {
            var response = new RegisterResponse();

            string insertString = $"insert into `personal` (`per_name`,`per_email`,`per_password`,`per_balance`)" +
                    $" values('{mer.MerName}','{mer.email}','{mer.password}','{mer.Balance}');";
            MySqlCommand command = new MySqlCommand(insertString, connection);
            command.ExecuteNonQuery();

            response.Message = $"{mer.MerName} has been added to Database successfully.";
            return response;
        }
    }
}
