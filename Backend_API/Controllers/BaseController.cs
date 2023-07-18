using Backend.Services;
using Backend.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        //private string PublicKey = "DigiCoin";
        //private string PrivateKey = "Greg";
        //RSAService.Generator(out PrivateKey, out PublicKey, int 1024);
    }
}
