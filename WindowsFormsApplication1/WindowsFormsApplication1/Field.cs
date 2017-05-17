using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireAndWaterGame
{
    public class Field
    {
        private Terrain[][] field;

        public readonly int Heigh;
        public readonly int Width;
        public readonly List<IMovingObjects> MovingObjects;

        public Terrain this[int row, int column]
        { 
            get
            {
                if (GeometryAndArithmetic.InRange(row, 0, Heigh) &&
                    GeometryAndArithmetic.InRange(column, 0, Width))
                    return field[row][column];
                else
                    throw new IndexOutOfRangeException();
            }
        }

        public Field(Level level)
        {
            string map = level.Map;
            Heigh = map.Count(c => c == '>');
            Width = map.Length / Heigh;
            field = new Terrain[Heigh][];
            var lines = map.Split('>');
            
            foreach (var row in Enumerable.Range(0, lines.Count() - 1))
            {
                var line = lines[row];
                field[row] = new Terrain[Width];
                foreach (var column in Enumerable.Range(0, line.Length - 1))
                {
                    var position = new Point(
                        column * Constants.TerrainSquareLength,
                        row * Constants.TerrainSquareLength);
                    var symbol = line[column];
                    if (symbol == '#')
                        field[row][column] = new Terrain(position, TerrainType.FullSquare);
                    if (symbol == '\\')
                        field[row][column] = new Terrain(position, TerrainType.DownLeftTriangle);
                    if (symbol == '/')
                        field[row][column] = new Terrain(position, TerrainType.DownRightTriangle);
                    if (symbol == 'L')
                        field[row][column] = new Terrain(position, TerrainType.DownLeftTriangle);
                    if (symbol == 'R')
                        field[row][column] = new Terrain(position, TerrainType.DownLeftTriangle);

                }
            }
            //MovingObjects =
        }
    }
}
