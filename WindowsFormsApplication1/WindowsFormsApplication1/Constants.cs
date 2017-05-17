using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireAndWaterGame
{
    static class Constants
    {
        public static readonly Dictionary<int, Level> Levels;

        static Constants()
        {
            Levels[0] = new Level(0,
                @"
                >############
                >#..........#
                >#..........#
                >#..........#
                >#...####...#
                >#..........#
                >#..........#
                >############
                "
                );
        }
    }
}
