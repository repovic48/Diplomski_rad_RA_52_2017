using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using restaurant_service.Model;

namespace restaurant_service.Services 
{
    public class TokenProvider
    {
        public TokenProvider()
        {

        }

        public string Create(Restaurant restaurant)
        {
            string secretKey = "69user_secret_1234567891069dugacki_kljuc";
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                [
                    new Claim(JwtRegisteredClaimNames.Sub, restaurant.id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, restaurant.email),
                    new Claim("is_account_active", restaurant.account_active.ToString()),
                    new Claim("is_account_suspended", restaurant.account_suspended.ToString()),
                    new Claim(ClaimTypes.Role, "Restaurant"),
                ]),
                Expires = DateTime.UtcNow.AddMinutes(60),
                SigningCredentials = credentials,
                Issuer = "Naruci.rs",
                Audience = "registered_restaurant"
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}