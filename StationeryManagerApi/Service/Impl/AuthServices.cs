using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using StationeryManagerLib.Entities;

namespace StationeryManagerApi.Service.Impl
{
    public class AuthServices : IAuthServices
    {
        private readonly IConfiguration _configuration;

        public AuthServices(IConfiguration configuration) {
            _configuration = configuration;
        }
        public string GenerateJwtToken(AccountModel account)
        { 
            string secretKey = _configuration["Jwt:Key"] ?? "";
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = "https://stationery.api.com",
                Audience = "https://stationery.com",
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, account.Id.ToString()),
                    new Claim(ClaimTypes.Name, account.Name),
                    new Claim(ClaimTypes.Email, account.Email),
                    new Claim(ClaimTypes.MobilePhone, account.Phone ?? ""),
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return tokenString;
        }

        // gán giá trị token vào ClaimsModel
        public ClaimModel GetClaimByToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadJwtToken(token);
            var claims = jwtToken.Claims.ToList();
            var claimModel = new ClaimModel
            {
                UserId = claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value,
                UserName = claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value,
                Email = claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value,
                Phone = claims.FirstOrDefault(c => c.Type == ClaimTypes.MobilePhone)?.Value
            };

            return claimModel;
        }
    }
}
