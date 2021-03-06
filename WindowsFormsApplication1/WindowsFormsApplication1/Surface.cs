﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireAndWaterGame
{
    public enum SurfaceType
    {
        Empty,
        Mud,
        Fire,
        Water
    };
    public class Surface
    {
        public Point Position { get; private set; }
        public Size Size { get { return Constants.SurfaceSize; } }
        public readonly SurfaceType Type;

        public Surface(Point position, SurfaceType type)
        {
            Position = new Point(position.X, position.Y);
            Type = type;
        }
    }
}
