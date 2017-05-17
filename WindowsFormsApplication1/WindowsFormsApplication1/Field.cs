using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireAndWaterGame
{
    class Field
    {
        private Terrain[,] field;

        public readonly int Width;
        public readonly int Heigh;
        public readonly List<IMovingObjects> MovingObjects;

        public Terrain this[int row, int column]
        { 
            get
            {
                if (GeometryAndArithmetic.InRange(row, 0, Heigh) &&
                    GeometryAndArithmetic.InRange(column, 0, Width))
                    return field[row, column];
                else
                    throw new IndexOutOfRangeException();
            }
        }

        public Field(Level level)
        {
            string map = level.Map;
            //Width = 
            //Heigh = 
            //field =
            //MovingObjects =
        }
    }
}
