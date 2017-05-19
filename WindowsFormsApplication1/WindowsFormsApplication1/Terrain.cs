using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireAndWaterGame
{
    public enum TerrainType
    {
        Empty,
        FullSquare,
        DownLeftTriangle,
        UpLeftTriangle,
        UpRightTriangle,
        DownRightTriangle
    };

    public class Terrain
    {
        public Point Position { get; private set; }
        public Size Size { get { return Constants.TerrainSize; } }
        public readonly TerrainType Type;
        public readonly SurfaceType Surface;
        public readonly int RowIndex;
        public readonly int ColumnIndex;

        public string Image = "images//simple_terrain.jpg";

        public Terrain(Point position, TerrainType type, SurfaceType surface, int rowIndex, int columnIndex)
        {
            Position = new Point(position.X, position.Y);
            Type = type;
            Surface = surface;
            RowIndex = rowIndex;
            ColumnIndex = columnIndex;
        }
    }
}
