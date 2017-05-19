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
        public static readonly int SurfaceHeigh = 100;
        public static readonly int HeroHeigh = 7000;
        public static readonly int HeroWidth = 4000;
        public static readonly int Step = 1500;
        public static readonly int JumpSpeed = -1300; 
        public static readonly Point Gravity;
        internal static int DyingTimeInTicks = 10;

        public static Size TerrainSize { get; private set; }
        public static Size SurfaceSize { get; private set; }
        public static Point SurfaceIndent { get; private set; }
        public static Size HeroSize { get; internal set; }
        
        // -1400 55, 1300 45
        static Constants()
        {
            TerrainSize = new Size(TerrainSquareLength, TerrainSquareLength);
            SurfaceSize = new Size(TerrainSquareLength / 9, SurfaceHeigh);
            SurfaceIndent = new Point(Constants.TerrainSquareLength / 9 * 4, -Constants.SurfaceHeigh);
            HeroSize = new Size(HeroWidth, HeroHeigh);
            Gravity = new Point(0, 45);

            Levels = new Dictionary<int, Level>();
            Levels[0] = new Level(0, new string[]
            { "#################################################",
              "#...............................................#",
              "#...............................................#",
              "#...............................................#",
              "#...............................................#",
              "#...............................................#",
              "#...............................................#",
              "#...............................................#",
              "#..............................#B#..............#",
              "#..............................###..............#",
              "#.........######fffffffffffff######.............#",
              "#...............................................#",
              "#...............................................#",
              "#....................WW.........................#",
              "###..................WW.........................#",
              "#.##.................WW.....................##O##",
              "#..##.......................................#####",
              "#...##......................................#####",
              "#...........................................#####",
              "#...........................................#####",
              "#.............##########wwwwwwwwwwww#############",
              "#........FF.....................................#",
              "#........FF.....................................#",
              "#........FF.....................................#",
              "###mmm#########mmm########mmm####################"
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
    }
}
