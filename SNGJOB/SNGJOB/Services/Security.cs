using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SNGJOB.Models.UserModels;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace SNGJOB.Services
{
    public class Security
    {
        public string Hash(string input)
        {
            var sHA256 = SHA256.Create();
            var hash = sHA256.ComputeHash(Encoding.UTF8.GetBytes(input));

            return Convert.ToBase64String(hash);
        }

        public string GenerateJSONWebToken(UserDetail user, IConfiguration configuration)
        {
            var SecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var Credentials = new SigningCredentials(SecurityKey, SecurityAlgorithms.HmacSha256);

            var Claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, user.user.id.ToString()),
                new Claim(JwtRegisteredClaimNames.Sub,user.fullName),
                new Claim(JwtRegisteredClaimNames.Email,user.user.email),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };

            var Token = new JwtSecurityToken(
                issuer: configuration["Jwt:Issuer"],
                audience: configuration["Jwt:Issuer"],
                Claims,
                expires: DateTime.Now.AddHours(6),
                signingCredentials: Credentials
                );

            var EncodeToken = new JwtSecurityTokenHandler().WriteToken(Token);
            return EncodeToken;
        }

        private static Random random = new Random();

        public static string RandomCharacter()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 1)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public string GenerateRandomKey(int lenth)
        {
            string secret = "";
            for (int i = 0; i < lenth; i++)
            {
                secret += RandomCharacter();
            }

            return secret;
        }


    }
}
