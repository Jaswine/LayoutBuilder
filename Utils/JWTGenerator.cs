using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace LayoutBuilder.Utils
{
    public class JWTGenerator
    {
        public string GenerateJwtToken(string userId) {
            string secretKey = "The_Lord_Of_The_Rings_And_The Hobbit_Or_There_and_Back_Again";
            int expirationMinutes = 1440;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secretKey);

             var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userId),
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(expirationMinutes),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public string DecodeJwtToken(string token)
        {
        string secretKey = "The_Lord_Of_The_Rings_And_The Hobbit_Or_There_and_Back_Again";
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(secretKey);

        var validationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false,
        };

        SecurityToken validatedToken;
        var principal = tokenHandler.ValidateToken(token, validationParameters, out validatedToken);

        var userIdClaim = principal.FindFirst(ClaimTypes.NameIdentifier);
        var userId = userIdClaim?.Value;

        return userId;
        }
    }
}