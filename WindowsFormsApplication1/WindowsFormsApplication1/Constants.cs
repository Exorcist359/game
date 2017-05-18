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
        public static readonly int koef = 100;
        public static readonly Dictionary<int, Level> Levels;
        public static readonly int TerrainSquareLength = 2500;
        public static readonly int HeroHeigh = 7000;
        public static readonly int HeroWidth = 4000;
        public static readonly int Step = 1000;
        public static readonly int JumpSpeed = -2500;
        public static readonly Point Gravity;

        static Constants()
        {
            TerrainSize = new Size(TerrainSquareLength, TerrainSquareLength);
            HeroSize = new Size(HeroWidth, HeroHeigh);
            Gravity = new Point(0, 25);

            Levels = new Dictionary<int, Level>();
            Levels[0] = new Level(0, new string[]
            { "############",
              "#..........#",
              "#..........#",
              "#..........#",
              "#..FF..WW..#",
              "#..FF..WW..#",
              "#..FF..WW..#",
              "############"
            });
            Levels[1] = new Level(1, new string[]
            { "############",
              "#L........R#",
              "#..........#",
              "#..........#",
              "#...####...#",
              "#..........#",
             @"#\......../#",
              "############"
             });
            Levels[2] = new Level(2, new string[]
            { "############",
              "#..........#",
              "#..........#",
              "#..........#",
              "#..FF..WW..#",
              "#..FF..WW..#",
              "#..FF..WW..#",
              "############"
             });
        }

        public static Size TerrainSize { get; private set; }
        public static Size HeroSize { get; internal set; }
    }
}
