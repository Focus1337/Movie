using System.Text;

namespace Reviefy.Services
{
    public static class JwtConfig
    {
        private const string JwtSecret = "123123123123123123123123123123";
        public static readonly byte[] JwtKey = Encoding.ASCII.GetBytes(JwtSecret);
    }
}