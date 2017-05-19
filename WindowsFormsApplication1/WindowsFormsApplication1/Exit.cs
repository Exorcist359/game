using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireAndWaterGame
{
    public class Exit
    {
        public Point Position { get; private set; }
        public Size Size { get { return Constants.TerrainSize; } }
        public readonly ElementType Type;

        public string Image = "images//simple_terrain.jpg";

        public Exit(Point position, ElementType type)
        {
            Position = new Point(position.X, position.Y);
            Type = type;
        }
    }
}
