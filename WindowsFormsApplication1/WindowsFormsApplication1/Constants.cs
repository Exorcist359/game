using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireAndWaterGame
{
    static class Constants
    {
        public static readonly Dictionary<int, Level> Levels;
        public static readonly int TerrainSquareLength = 100;
        public static readonly int HeroHeigh = 120;
        public static readonly int HeroWidth = 60;

        static Constants()
        {
            TerrainSize = new Size(TerrainSquareLength, TerrainSquareLength);
            HeroSize = new Size(HeroWidth, HeroHeigh);
            Levels = new Dictionary<int, Level>();
            Levels[0] = new Level(0,
@">############
>#..........#
>#..........#
>#..........#
>#...####...#
>#..........#
>#..........#
>############"
                );
            Levels[1] = new Level(1,
                @"
>############
>#L........R#
>#..........#
>#..........#
>#...####...#
>#..........#
>#\......../#
>############
"
                );
            Levels[2] = new Level(2,
                @"
>############
>#L........R#
>#..........#
>#..........#
>#...####...#
>#...W..F...#
>#\..W..F../#
>############
"
                );
        }

        public static Size TerrainSize { get; private set; }
        public static Size HeroSize { get; internal set; }
    }
}
