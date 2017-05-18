using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireAndWaterGame
{
    static class GeometryAndArithmetic
    {
        public static bool InRange(int number, int left, int rigth)
        {
            return left <= number && number < rigth;
        }
    }
}
