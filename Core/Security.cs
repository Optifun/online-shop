using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;

namespace OnlineShop.Core
{
    public static class Security
    {
        public static string Hash(string text) =>
            Convert.ToHexString(KeyDerivation.Pbkdf2(
                password: text,
                salt: new byte[] {138, 14, 25},
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));
    }
}