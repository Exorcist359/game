using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireAndWaterGame
{
    public enum ElementType { Fire, Water }
    public class Hero : IMovingObjects
    {
        public ElementType Type { get; private set; }
        public Point Position { get; private set; }
        public Point StartPosition { get; private set; }
        public Field Field { get; private set; }
        public bool IsDying { get; private set; }
        public bool IsDead { get; private set; }
        public int TimeToDeath { get; private set; }
        public bool Win { get; private set; }
        private List<Point> Moves;
        private List<Point> Speeds;

        public string Image
        {
            get
            {
                string typeName;
                if (Type == ElementType.Fire)
                    typeName = "fire";
                else
                    typeName = "water";

                return "images//simple" + typeName;
            }
        }

        public Size Size
        {
            get
            {
                return Constants.HeroSize;
            }
        }

        public Hero(Point position, ElementType type, Field field)
        {
            Position = new Point(position.X, position.Y);
            StartPosition = new Point(position.X, position.Y);
            Type = type;
            Field = field;
            Moves = new List<Point>();
            Speeds = new List<Point>();
            IsDying = false;
            IsDead = false;
            TimeToDeath = Constants.DyingTimeInTicks;
        }

        public void MoveLeft()
        {
            var move = new Point(-Constants.Step, 0);
            Moves.Add(move);
        }

        public void MoveRight()
        {
            var move = new Point(Constants.Step, 0);
            Moves.Add(move);
        }

        public void Jump()
        {
            if (Speeds.Count == 1)
            {
                var speed = new Point(0, Constants.JumpSpeed);
                Speeds.Add(speed);
            }
        }

        public void MoveDown()
        {
        }

        public void MoveUp()
        {
        }

        public void RealiseMoves()
        {
            if (IsDead || Win)
            {
                return;
            }
            if (IsDying)
            {
                TimeToDeath--;
                if (TimeToDeath == 0)
                {
                    IsDead = true;
                }
                return;
            }
            var newSpeeds = new List<Point>();
            Point sum = new Point(0,0);
            foreach (var speed in Speeds)
            {
                sum = new Point(sum.X + speed.X, sum.Y + speed.Y);
            }
            if (TryToMove(sum))
            {
                Speeds.Add(Constants.Gravity);
                //foreach (var speed in Speeds)
                //{
                //    var newSpeed = new Point(
                //  speed.X + Constants.Gravity.X,
                //  speed.Y + Constants.Gravity.Y);
                //    //if (newSpeed.X != 0 || newSpeed.Y != 0)
                //    newSpeeds.Add(newSpeed);
                //}
            }
            else
            {
                while (!TryToMove(sum))
                {
                    sum = new Point(sum.X / 2, sum.Y / 2);
                }
                Speeds = new List<Point>();
                Speeds.Add(Constants.Gravity);
            }

            foreach (var move in Moves)
            {
                //sum = new Point(sum.X + move.X, sum.Y + move.Y);
                TryToMove(move);
            }
            Moves = new List<Point>();

            if (IsInDanger())
            {
                IsDying = true;
            }
            if (IsOnExit())
            {
                Win = true;
            }
        }

        private bool IsOnExit()
        {
            Exit exit;
            if (Type == ElementType.Water)
                exit = Field.WaterExit;
            else
                exit = Field.FireExit;
            var exitRect = new Rectangle(exit.Position, exit.Size);
            if (IsIntersectedWith(exitRect))
            {
                return true;
            }
            return false;
        }

        private bool IsInDanger()
        {
            foreach (var surface in Field.Danger
                .Where(sur => sur.Type.ToString() != this.Type.ToString()))
            {
                var surfaceRect = new Rectangle(surface.Position, surface.Size);
                if (IsIntersectedWith(surfaceRect))
                {
                    return true;
                }
            }
            return false;
        }

        private bool TryToMove(Point move)
        {
            var newPosition = new Point(Position.X + move.X, Position.Y + move.Y);
            var rect = new Rectangle(newPosition, Size);
            if (GeometryAndArithmetic.InRange(Position.X, 0, Field.Width * Constants.TerrainSquareLength) &&
                GeometryAndArithmetic.InRange(Position.Y, 0, Field.Heigh * Constants.TerrainSquareLength))
            {
                if (!DoesIntersect(rect))
                {
                    if (GeometryAndArithmetic.InRange(Position.X, 0, Field.Width * Constants.TerrainSquareLength) &&
                        GeometryAndArithmetic.InRange(Position.Y, 0, Field.Heigh * Constants.TerrainSquareLength))
                    {
                        Position = newPosition;
                        return true;
                    }
                }
            }
            return false;
        }

        private bool DoesIntersect(Rectangle heroRect)
        {
            //foreach (var terr in Field)
            //{
            //    if (terr.Type == TerrainType.Empty)
            //    {
            //        continue;
            //    }
            //    var terrRect = new Rectangle(terr.Position, terr.Size);
            //    if (IsIntersectedWith(terrRect))
            //    {
            //        return true;
            //    }
            //}
            //return false;
            return Field
                .Where(terrain => terrain.Type != TerrainType.Empty)
                .Select(terrain => new Rectangle(terrain.Position, terrain.Size))
                .Any(rect => AreIntersected(heroRect, rect));

        }

        private bool AreIntersected(Rectangle rect1, Rectangle rect2)
        {
            if (rect1.IntersectsWith(rect2))
            {
                var r = new Rectangle(rect2.Location, rect2.Size);
                r.Intersect(rect1);
                return !r.IsEmpty;
            }
            return false;
        }

        private bool IsIntersectedWith(Rectangle toIntersect)
        {
            var currentState = new Rectangle(Position, Size);
            return AreIntersected(currentState, toIntersect);
        }

    }
}
