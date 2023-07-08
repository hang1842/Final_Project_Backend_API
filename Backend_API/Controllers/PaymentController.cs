using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using Backend.Services;

namespace Backend_API.Controllers
{
    public class PaymentController : BaseController
    {
        private string PublicKey = "DigiCoin";
        private string PrivateKey = "Greg";
        
        RSAService.Generator();
        
    }
}
