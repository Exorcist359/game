﻿using System;
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
        }

        public void RealiseMoves()
        {
            foreach(var move in Moves)
            {
                var newPosition = new Point(Position.X + move.X, Position.Y + move.Y);
                MoveOnNewPosition(newPosition);
            }
            Moves = new List<Point>();
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

        private void MoveOnNewPosition(Point newPosition)
        {
            var rect = new Rectangle(newPosition, Size);
            if (!DoesIntersect(rect))
            {
                Position = newPosition;
            }
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

        public void Jump()
        {
            throw new NotImplementedException();
        }

        public void MoveDown()
        {
        }

        public void MoveUp()
        {
        }
    }
}
