using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Backend.Services
{
    public class AuthService
    {
        private readonly IConfiguration _config;

        public AuthService(IConfiguration config)
        {
            _config = config;
        }

        public string generateToken(string email)
        {
            var issuer = _config["JwtSettings:Issuer"];
            var audience = _config["JwtSettings:Audience"];
            var claims = new List<Claim>{
                   new Claim("email", email)};

            var notBefore = DateTime.Now;
            var expires = DateTime.Now.AddDays(3);

            var signingKeyGate = _config["JwtSettings:SigningKey"];
            var signingKeyBytes = Encoding.UTF8.GetBytes(signingKeyGate!);
            var signingKey = new SymmetricSecurityKey(signingKeyBytes);

            var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

            var jwtToken = new JwtSecurityToken(
                issuer,
                audience,
                claims,
                notBefore,
                expires,
                signingCredentials
            );

            var encodejwt = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            return encodejwt;
        }




    }
}
