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
        public static int GenerateNumber(int minimum, int maximum)
        {
            var random = new Random();
            return random.Next(minimum, maximum);
        }
    }
}
