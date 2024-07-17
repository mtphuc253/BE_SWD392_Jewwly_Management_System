using JewelleryShop.DataAccess.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JewelleryShop.DataAccess.Utils
{
    public static class GenerateJsonWebTokenString
    {
        public static string GenerateJsonWebToken(this staff employee, string secretKey, DateTime now, double expiration)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var secretKeyBytes = Encoding.UTF8.GetBytes(secretKey);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, employee.StaffId),
                new Claim(ClaimTypes.Role, employee.RoleId.ToString() ?? string.Empty),
                new Claim(ClaimTypes.Name, employee.FullName ?? string.Empty),
                new Claim(ClaimTypes.Email, employee.Email ?? string.Empty),
                new Claim("UserName", employee.UserName ?? string.Empty),
                new Claim("Status", employee.Status ?? string.Empty),
                new Claim("TokenId", Guid.NewGuid().ToString())
            };

            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = now.AddMinutes(expiration), // Adjust the expiration time
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKeyBytes), SecurityAlgorithms.HmacSha512Signature)
            };

            var token = jwtTokenHandler.CreateToken(tokenDescription);


            return jwtTokenHandler.WriteToken(token);
        }
    }
}
