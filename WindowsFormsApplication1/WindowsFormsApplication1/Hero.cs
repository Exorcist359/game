using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireAndWaterGame
{
    enum ElementType { Fire, Water }
    class Hero : IMovingObjects
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
            Position = new Point(position.X, position.Y);
            Type = type;
            Field = field;
        }

        public void MoveLeft()
        {
            throw new NotImplementedException();
        }

        public void MoveRight()
        {
            throw new NotImplementedException();
        }

        public void MoveDown()
        {
            throw new NotImplementedException();
        }

        public void MoveUp()
        {
            throw new NotImplementedException();
        }
    }
}
