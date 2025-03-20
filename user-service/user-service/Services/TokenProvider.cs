using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using user_service.Model;

namespace user_service.Services 
{
    public class TokenProvider
    {
        public TokenProvider()
        {

        }

        public string Create(User user)
        {
            string secretKey = "69user_secret_1234567891069dugacki_kljuc";
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                [
                    new Claim(JwtRegisteredClaimNames.Sub, user.id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, user.email),
                    new Claim(ClaimTypes.Role, user.user_type.ToString()),
                    new Claim("is_account_active", user.is_account_active.ToString())
                ]),
                Expires = DateTime.UtcNow.AddMinutes(60),
                SigningCredentials = credentials,
                Issuer = "Naruci.rs",
                Audience = "registered_user"
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}