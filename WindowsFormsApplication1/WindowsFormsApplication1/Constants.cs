﻿using System;
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

        static Constants()
        {
            TerrainSize = new Size(TerrainSquareLength, TerrainSquareLength);
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

        public static Size TerrainSize { get; private set; }

    }
}