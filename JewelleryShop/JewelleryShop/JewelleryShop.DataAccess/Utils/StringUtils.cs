using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelleryShop.DataAccess.Utils
{
    public static class StringUtils
    {
        public static string HashPassword(string input)
        {
            return BCrypt.Net.BCrypt.HashPassword(input);
        }
        public static string HashPassword(string input, string salt)
        {
            return BCrypt.Net.BCrypt.HashPassword(input, salt);
        }
        public static bool VerifyPassword(string input, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(input, hash);
        }
    }
}
