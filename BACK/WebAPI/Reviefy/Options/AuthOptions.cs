using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Reviefy.Options
{
    public class AuthOptions
    {
        public string Issuer { get; set; } // издатель токена
        
        public string Audience { get; set; } // потребитель токена
        public string Secret { get; set; }   // ключ для шифрации
        
        public int TokenLifeTime { get; set; } // время жизни токена - 1 минута

        public SymmetricSecurityKey GetSymmetricSecurityKey() => 
            new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Secret));
    }
}