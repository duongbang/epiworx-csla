using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Epiworx.Business.Security.Helpers
{
    public class PasswordHelper
    {
        internal static bool Validate(string password)
        {
            var result = true;

            if (string.IsNullOrEmpty(password.Trim()))
            {
                result = false;
            }

            if (password.Trim().Length < 6)
            {
                result = false;
            }

            return result;
        }

        public static string Salt(string salt, string password)
        {
            var sha1 = new SHA1CryptoServiceProvider();

            var byteValue = Encoding.UTF8.GetBytes(salt + password);

            var byteHash = sha1.ComputeHash(byteValue);

            sha1.Clear();

            return Convert.ToBase64String(byteHash);
        }

        internal static bool ComparePasswords(string salt, string password, string storedPassword)
        {
            var passwordHash = Salt(salt, password);

            return string.Compare(storedPassword, passwordHash) == 0;
        }

        public static string GetSalt(int length)
        {
            var randomArray = new byte[length];

            var rng = new RNGCryptoServiceProvider();

            rng.GetBytes(randomArray);

            var randomString = Convert.ToBase64String(randomArray);

            return randomString.Substring(0, length);
        }

        public static string GetRandomPassword(int length)
        {
            var chars = "$%#@!*abcdefghijklmnopqrstuvwxyz1234567890?;:ABCDEFGHIJKLMNOPQRSTUVWXYZ^&".ToCharArray();
            var password = string.Empty;
            var random = new Random();

            for (int i = 0; i < length; i++)
            {
                int x = random.Next(1, chars.Length);

                if (!password.Contains(chars.GetValue(x).ToString()))
                {
                    password += chars.GetValue(x);
                }
                else
                {
                    i--;
                }
            }

            return password;
        }
    }
}
