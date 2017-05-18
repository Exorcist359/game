using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireAndWaterGame
{
    public class Field : IEnumerable<Terrain>
    {
        private List<List<Terrain>> field;

        public readonly int Heigh;
        public readonly int Width;
        public readonly List<IMovingObjects> MovingObjects;
        public readonly Hero WaterHero;
        public readonly Hero FireHero;

        public Field(Level level, Game game)
        {
            var map = level.Map;
            Heigh = map.Length;
            Width = map[0].Length;
            MovingObjects = new List<IMovingObjects>();
            field = new List<List<Terrain>>();
            MovingObjects = new List<IMovingObjects>();
            WaterHero = null;
            FireHero = null;

            foreach (var row in Enumerable.Range(0, Heigh))
            {
                var list = new List<Terrain>();
                field.Add(list);
                foreach (var column in Enumerable.Range(0, Width))
                {
                    var position = new Point(
                        column * Constants.TerrainSquareLength,
                        row * Constants.TerrainSquareLength);
                    var symbol = map[row][column];
                    if (symbol == '#')
                        list.Add(new Terrain(position, TerrainType.FullSquare, row, column));
                    else if (symbol == '\\')
                        list.Add(new Terrain(position, TerrainType.DownLeftTriangle, row, column));
                    else if (symbol == '/')
                        list.Add(new Terrain(position, TerrainType.DownRightTriangle, row, column));
                    else if (symbol == 'L')
                        list.Add(new Terrain(position, TerrainType.DownLeftTriangle, row, column));
                    else if (symbol == 'R')
                        list.Add(new Terrain(position, TerrainType.DownLeftTriangle, row, column));
                    else
                        list.Add(new Terrain(position, TerrainType.Empty, row, column));

                    var heroPosition = new Point(
                        position.X + (Constants.TerrainSquareLength  * 2- Constants.HeroWidth) / 2,
                        position.Y + (Constants.TerrainSquareLength * 3 - Constants.HeroHeigh));
                    if (symbol == 'W' && WaterHero == null)
                    {
                        WaterHero = new Hero(heroPosition, ElementType.Water, this);
                        MovingObjects.Add(WaterHero);
                    }
                    if (symbol == 'F' && FireHero == null)
                    {
                        FireHero = new Hero(heroPosition, ElementType.Fire, this);
                        MovingObjects.Add(FireHero);
                    }
                }
            }
        }

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

        public IEnumerator<Terrain> GetEnumerator()
        {
            foreach (var line in field)
            {
                foreach(var elem in line)
                {
                    yield return elem;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
