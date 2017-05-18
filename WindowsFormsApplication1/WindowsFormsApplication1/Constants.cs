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
        public static readonly int TerrainSquareLength = 50;
        public static readonly int HeroHeigh = 70;
        public static readonly int HeroWidth = 40;
        public static readonly int Step = 10;

        static Constants()
        {
            TerrainSize = new Size(TerrainSquareLength, TerrainSquareLength);
            HeroSize = new Size(HeroWidth, HeroHeigh);

            Levels = new Dictionary<int, Level>();
            Levels[0] = new Level(0, new string[]
            { "############",
              "#..........#",
              "#..........#",
              "#..........#",
              "#...####...#",
              "#...F..W...#",
              "#...F..W...#",
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
              "#...####...#",
              "#...F..W...#",
              "#...F..W...#",
              "############"
             });
        }

        public static Size TerrainSize { get; private set; }
        public static Size HeroSize { get; internal set; }
    }
}
