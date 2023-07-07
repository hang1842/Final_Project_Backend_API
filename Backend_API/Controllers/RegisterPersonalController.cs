using Backend.Dtos;
using Backend_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace Backend_API.Controllers
{
    public class RegisterPersonalController : BaseController
    {
        const string connectionString = "Server=localhost;Database=payment;Uid=root;Pwd=;";
        private static MySqlConnection connection = new MySqlConnection(connectionString);

        [HttpPost]
        public ActionResult<RegisterResponse> AddNewMember(RegisterPersonalRequest per)
        {
            var response = new RegisterResponse();

            string insertString = $"insert into `Personal` (`Name`,`Email`,`Password`,`Balance`)" +
                    $" values('{per.PerName}','{per.email}','{per.password}','{per.Balance}');";
            MySqlCommand command = new MySqlCommand(insertString, connection);
            command.ExecuteNonQuery();

            response.Message = $"{per.PerName} has been added to Database successfully.";
            return response;
        }
    }
}
