using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireAndWaterGame
{
    enum TerrainType
    {
        Empty,
        FullSquare,
        DownLeftTriangle,
        UpLeftTriangle,
        UpRightTriangle,
        DownRightTriangle
    };

    class Terrain
    {
        public Point Position { get; private set; }
        public Size Size { get { return Constants.TerrainSize; } }
        public readonly TerrainType Type;

        public string Image = "images//simple_terrain.jpg";

        public Terrain(Point position, TerrainType type)
        {
            Position = new Point(position.X, position.Y);
            Type = type;
        }
    }
}
