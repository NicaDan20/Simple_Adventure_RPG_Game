using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Engine
{
    public static class RandomNumberGenerator
    {
        private static readonly RNGCryptoServiceProvider _generator = new();
        public static int GenerateNumber(int minimum, int maximum)
        {
            byte[] randomNumber = new byte[1];
            _generator.GetBytes(randomNumber);
            double asciiValueOfRandomChar = Convert.ToDouble(randomNumber[0]);
            double multiplier = Math.Max(0, (asciiValueOfRandomChar / 255d) - 0.00000000001d);
            int range = maximum - minimum + 1;
            double randomValueInRange = Math.Floor(multiplier * range);
            return (int)randomValueInRange;
        }
    }
}
