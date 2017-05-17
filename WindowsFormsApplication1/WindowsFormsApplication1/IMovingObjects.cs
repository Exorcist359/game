using System.Drawing;

namespace FireAndWaterGame
{
    public interface IMovingObjects
    {
        Field Field { get; }
        Point Position { get; }
        Point StartPosition { get; }
        void MoveLeft();
        void MoveRight();
        void MoveDown();
        void MoveUp();
        Size Size { get; }

    }
}