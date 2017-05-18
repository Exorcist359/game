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
        private List<Point> Moves;
        private List<Point> Speeds;
 
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
        }

        public void RealiseMoves()
        {
            var newSpeeds = new List<Point>();
            Speeds.Add(Constants.Gravity);
            foreach (var speed in Speeds)
            {
                if (TryToMove(speed))
                {
                    var newSpeed = new Point(
                      speed.X + Constants.Gravity.X,
                      speed.Y + Constants.Gravity.Y);
                    //if (newSpeed.X != 0 || newSpeed.Y != 0)
                    newSpeeds.Add(newSpeed);
                }
            }
            Speeds = newSpeeds;
            foreach (var move in Moves)
            {
                TryToMove(move);
            }
            Moves = new List<Point>();
        }

        private bool TryToMove(Point move)
        {
            var newPosition = new Point(Position.X + move.X, Position.Y + move.Y);
            var rect = new Rectangle(newPosition, Size);
            if (!DoesIntersect(rect))
            {
                Position = newPosition;
                return true;
            }
            return false;
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
            var speed = new Point(0, Constants.JumpSpeed);
            Speeds.Add(speed);
        }

        public void MoveDown()
        {
        }

        public void MoveUp()
        {
        }

        private void MoveOnNewPosition(Point newPosition)
        {
        }

        private bool DoesIntersect(Rectangle heroRect)
        {
            foreach (var terr in Field)
            {
                if (terr.Type == TerrainType.Empty)
                    continue;
                var terrRect = new Rectangle(terr.Position, terr.Size);

                if (heroRect.IntersectsWith(terrRect))
                {
                    terrRect.Intersect(heroRect);
                    if (!terrRect.IsEmpty)
                        return true;
                }
            }
            return false;
        }

    }
}
