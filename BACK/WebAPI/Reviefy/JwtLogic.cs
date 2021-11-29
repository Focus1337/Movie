// using System;
// using System.IdentityModel.Tokens.Jwt;
// using System.Linq;
// using System.Security.Claims;
// using System.Text;
// using Microsoft.IdentityModel.Tokens;
//
// namespace Reviefy.API
// {
//    public class JwtLogic
//     {
//         public string GenerateJwtToken(int accountId)
//         {
//             var tokenHandler = new JwtSecurityTokenHandler();
//             var key = Encoding.ASCII.GetBytes("[SECRET USED TO SIGN AND VERIFY JWT TOKENS, IT CAN BE ANY STRING]");
//             var tokenDescriptor = new SecurityTokenDescriptor
//             {
//                 Subject = new ClaimsIdentity(new[] { new Claim("id", accountId.ToString()) }),
//                 Expires = DateTime.UtcNow.AddDays(7),
//                 SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
//             };
//             var token = tokenHandler.CreateToken(tokenDescriptor);
//             return tokenHandler.WriteToken(token);
//         }
//         
//         public int? ValidateJwtToken(string token)
//         {
//             var tokenHandler = new JwtSecurityTokenHandler();
//             var key = Encoding.ASCII.GetBytes("[SECRET USED TO SIGN AND VERIFY JWT TOKENS, IT CAN BE ANY STRING]");
//             try
//             {
//                 tokenHandler.ValidateToken(token, new TokenValidationParameters
//                 {
//                     ValidateIssuerSigningKey = true,
//                     IssuerSigningKey = new SymmetricSecurityKey(key),
//                     ValidateIssuer = false,
//                     ValidateAudience = false,
//                     // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
//                     ClockSkew = TimeSpan.Zero
//                 }, out SecurityToken validatedToken);
//
//                 var jwtToken = (JwtSecurityToken)validatedToken;
//                 var accountId = int.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);
//
//                 // return account id from JWT token if validation successful
//                 return accountId;
//             }
//             catch
//             {
//                 // return null if validation fails
//                 return null;
//             }
//         }
//     }
// }