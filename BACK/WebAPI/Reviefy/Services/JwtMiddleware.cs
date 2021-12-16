using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using Reviefy.DataConnection;

namespace Reviefy.Services
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtMiddleware(RequestDelegate next) =>
            _next = next;

        public void Invoke(HttpContext context, AppDataConnection dataConnection)
        {
            var token = context.Request.Cookies["Authorization"];
            if (token is not null && token != string.Empty)
                AttachAccountToContext(context, dataConnection, token);

            _next(context);
        }

        private void AttachAccountToContext(HttpContext context, AppDataConnection dataConnection, string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Config.JwtKey),
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero
            }, out var validatedToken);

            var jwtToken = validatedToken as JwtSecurityToken;
            var accountId = Guid.Parse(jwtToken!.Claims.First(x => x.Type is "id").Value);

            context.Items["User"] = dataConnection.User.FirstOrDefault(x => x.UserId == accountId);
        }
    }
}