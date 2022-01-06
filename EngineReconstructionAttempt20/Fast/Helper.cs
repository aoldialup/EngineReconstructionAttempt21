using System;
using System.Collections.Generic;
using System.Text;

namespace EngineReconstructionAttempt20
{
    class Helper
    {
        private static readonly Random random = new Random();

        public static int GetRandomInt(int min, int max)
        {
            return random.Next(min, max);

        }

        public static float GetRandomFloat(float min, float max)
        {
            double val = (random.NextDouble() * (max - min) + min);
            return (float)val;
        }
    }
}
