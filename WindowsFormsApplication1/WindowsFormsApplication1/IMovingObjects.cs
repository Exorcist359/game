using System.Drawing;

namespace FireAndWaterGame
{
    public interface IMovingObjects
    {
        Point Position { get; }
        Point StartPosition { get; }
        void MoveLeft();
        void MoveRight();
        void MoveDown();
        void MoveUp();
    }
}