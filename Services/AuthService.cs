using FacebookApi.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System;
using Microsoft.AspNetCore.Http;

namespace FacebookApi.Services
{
    public class AuthService
    {
        public readonly ISecretSettings _secretSettings;

        public AuthService(ISecretSettings secretSettings) {
            _secretSettings = secretSettings;
        }


        public string Login(string id)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_secretSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, id)
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenStr = tokenHandler.WriteToken(token);

            return tokenStr;
        }

        public string GetIdentity(HttpContext context)
        {
            var claimsIdentity = context.User.Identity as ClaimsIdentity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.Name)?.Value;
            return userId;
        }
    }
}
