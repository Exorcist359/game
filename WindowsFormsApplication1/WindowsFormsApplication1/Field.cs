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
            var map = level.Map;
            Heigh = map.Length;
            Width = map[0].Length;
            field = new Terrain[Heigh][];

            Hero waterHero = null, fireHero = null;

            foreach (var row in Enumerable.Range(0, Heigh))
            {
                var line = map[row];
                field[row] = new Terrain[Width];
                foreach (var column in Enumerable.Range(0, line.Length - 1))
                {
                    var position = new Point(
                        column * Constants.TerrainSquareLength,
                        row * Constants.TerrainSquareLength);
                    var symbol = line[column];
                    if (symbol == '#')
                        field[row][column] = new Terrain(position, TerrainType.FullSquare);
                    else if (symbol == '\\')
                        field[row][column] = new Terrain(position, TerrainType.DownLeftTriangle);
                    else if (symbol == '/')
                        field[row][column] = new Terrain(position, TerrainType.DownRightTriangle);
                    else if (symbol == 'L')
                        field[row][column] = new Terrain(position, TerrainType.DownLeftTriangle);
                    else if (symbol == 'R')
                        field[row][column] = new Terrain(position, TerrainType.DownLeftTriangle);
                    else
                        field[row][column] = new Terrain(position, TerrainType.Empty);

                    var heroPosition = new Point(
                        position.X + (Constants.TerrainSquareLength - Constants.HeroWidth) / 2,
                        position.Y + (Constants.TerrainSquareLength * 2 - Constants.HeroHeigh));
                    if (symbol == 'W' && waterHero == null)
                    {
                        waterHero = new Hero(heroPosition, ElementType.Water, this);
                        MovingObjects.Add(waterHero);
                    }
                    if (symbol == 'F' && fireHero == null)
                    {
                        fireHero = new Hero(heroPosition, ElementType.Fire, this);
                        MovingObjects.Add(fireHero);
                    }
                }
                
            }
            int x = 0;
            //MovingObjects =
        }
    }
}
