using System;
using System.Security.Cryptography;
using AdvertAPI.Common;
using AdvertAPI.Models;

namespace AdvertAPI.Generators
{
    public class HashSaltGenerator
    {
        public static HashSalt GenerateSaltedHash( string password)
        {
            var saltBytes = new byte[Constants.SALTS_LENGTH];
            var provider = new RNGCryptoServiceProvider();
            provider.GetNonZeroBytes(saltBytes);
            var salt = Convert.ToBase64String(saltBytes);

            var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, saltBytes, 10000);
            var hashPassword = Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256));

            HashSalt hashSalt = new HashSalt(hashPassword, salt);
            return hashSalt;
        }
    }
}