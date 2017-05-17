using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireAndWaterGame
{
    class Terrain
    {
        public Point Position { get; private set; }
        public static string Image = "images//simple_terrain.jpg";

        public Terrain(Point position)
        {
            Position = new Point(position.X, position.Y);
        }
    }
}
