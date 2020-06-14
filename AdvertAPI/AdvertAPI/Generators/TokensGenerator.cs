using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using AdvertAPI.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace AdvertAPI.Generators
{
    public class TokensGenerator
    {
        public static AccessToken GenerateAccessToken(int clientId, IConfiguration configuration)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var expirationDateTime = DateTime.Now.AddMinutes(5);

            var token = new JwtSecurityToken(
                issuer: configuration["Jwt:Issuer"],
                audience: configuration["Jwt:Issuer"],
                claims: null,
                expires: expirationDateTime,
                signingCredentials: credentials);

            var accessToken = new JwtSecurityTokenHandler().WriteToken(token);

            AccessToken actualAccessToken = new AccessToken
            {
                IdClient = clientId,
                IdAccessToken = 1,
                Token = accessToken,
                IssueDateTime = DateTime.Now,
                ExpirationDateTime = expirationDateTime
            };

            return actualAccessToken;
        }
        public static RefreshToken GenerateRefreshToken(int clientId, AccessToken accessToken)
        {
            string token = Guid.NewGuid().ToString();
            DateTime issueDate = accessToken.IssueDateTime;

            RefreshToken actualRefreshToken = new RefreshToken
            {
                IdClient = clientId,
                IdRefreshToken = 1,
                Token = token,
                IssueDateTime = issueDate
            };
            return actualRefreshToken;
        }
    }
}