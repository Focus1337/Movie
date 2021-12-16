using System.Text;

namespace Reviefy
{
    public static class Config
    {
        private const string JwtSecret = "123123123123123123123123123123";
        public static readonly byte[] JwtKey = Encoding.ASCII.GetBytes(JwtSecret);
    }
}