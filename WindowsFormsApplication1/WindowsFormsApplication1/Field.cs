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
        public readonly List<Surface> Danger;
        public readonly Hero WaterHero;
        public readonly Hero FireHero;
        public readonly Exit WaterExit;
        public readonly Exit FireExit;

        public Field(Level level, Game game)
        {
            var map = level.Map;
            Heigh = map.Length;
            Width = map[0].Length;
            MovingObjects = new List<IMovingObjects>();
            field = new List<List<Terrain>>();
            MovingObjects = new List<IMovingObjects>();
            Danger = new List<Surface>();
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
                    var surfacePosition = new Point(
                        position.X + Constants.SurfaceIndent.X, 
                        position.Y + Constants.SurfaceIndent.Y);
                    var symbol = map[row][column];
                    if (symbol == '#')
                        list.Add(new Terrain(position, TerrainType.FullSquare, SurfaceType.Empty, row, column));
                    else if (symbol == '\\')
                        list.Add(new Terrain(position, TerrainType.DownLeftTriangle, SurfaceType.Empty, row, column));
                    else if (symbol == '/')
                        list.Add(new Terrain(position, TerrainType.DownRightTriangle, SurfaceType.Empty, row, column));
                    else if (symbol == 'L')
                        list.Add(new Terrain(position, TerrainType.DownLeftTriangle, SurfaceType.Empty, row, column));
                    else if (symbol == 'R')
                        list.Add(new Terrain(position, TerrainType.DownLeftTriangle, SurfaceType.Empty, row, column));
                    else if (symbol == 'm')
                    {
                        list.Add(new Terrain(position, TerrainType.FullSquare, SurfaceType.Mud, row, column));
                        Danger.Add(new Surface(surfacePosition, SurfaceType.Mud));
                    }
                    else if (symbol == 'f')
                    {
                        list.Add(new Terrain(position, TerrainType.FullSquare, SurfaceType.Fire, row, column));
                        Danger.Add(new Surface(surfacePosition, SurfaceType.Fire));
                    }
                    else if (symbol == 'w')
                    {
                        list.Add(new Terrain(position, TerrainType.FullSquare, SurfaceType.Water, row, column));
                        Danger.Add(new Surface(surfacePosition, SurfaceType.Water));
                    }
                    else if (symbol == 'B')
                    {
                        WaterExit = new Exit(surfacePosition, ElementType.Water);
                        list.Add(new Terrain(position, TerrainType.FullSquare, SurfaceType.Empty, row, column));
                    }
                    else if (symbol == 'O')
                    {
                        FireExit = new Exit(surfacePosition, ElementType.Fire);
                        list.Add(new Terrain(position, TerrainType.FullSquare, SurfaceType.Empty, row, column));
                    }
                    else
                        list.Add(new Terrain(position, TerrainType.Empty, SurfaceType.Empty, row, column));

                    var heroPosition = new Point(
                        position.X + (Constants.TerrainSquareLength * 2 - Constants.HeroWidth) / 2,
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
