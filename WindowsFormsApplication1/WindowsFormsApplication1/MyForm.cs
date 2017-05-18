using FireAndWaterGame;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    class MyForm : Form
    {
        public MyForm()
        {
            DoubleBuffered = true;
            var game = new Game();
            ClientSize = new Size(Constants.TerrainSquareLength * game.Field.Width, 
                                    Constants.TerrainSquareLength * game.Field.Heigh);

            var path = @"A:\Users\Александр\Documents\GitHub\game\WindowsFormsApplication1\WindowsFormsApplication1\images\";
            BackgroundImage = Image.FromFile(path + "background.jpg");

            var pathToFireImg = path + "fireboy_face.png";
            var pathToWaterImg = Image.FromFile(path + "simple_water.jpg");

            PaintEventHandler drawingField = (sender, args) => {
                for (var row = 0; row < game.Field.Heigh; row++)
                    for (var column = 0; column < game.Field.Width; column++)
                    {
                        if (game.Field[row, column].Type == TerrainType.FullSquare)
                        {
                            Bitmap myBitmap = new Bitmap(path + "terrain.png");
                            args.Graphics.DrawImage(myBitmap, game.Field[row, column].Position);
                        }
                    }

                Bitmap hero = new Bitmap(pathToFireImg);
                args.Graphics.DrawImage(hero, game.Field.FireHero.Position);

                hero = new Bitmap(pathToWaterImg);
                args.Graphics.DrawImage(hero, game.Field.WaterHero.Position);
            };

            Paint += drawingField;

            KeyDown += (sender, args) =>
            {
                switch (args.KeyCode)
                {
                    case Keys.D:
                        game.Field.FireHero.MoveRight();
                        pathToFireImg = path + "1.gif";
                        break;

                    case Keys.A:
                        game.Field.FireHero.MoveLeft();
                        break;

                    case Keys.Right:
                        game.Field.WaterHero.MoveRight();
                        break;

                    case Keys.Left:
                        game.Field.WaterHero.MoveLeft();
                        break;
                }
                
            };

            KeyUp += (sender, args) =>
            {
                switch (args.KeyCode)
                {
                    case Keys.D:
                        pathToFireImg = path + "fireboy_face.png";
                        break;
                }
            };

            var time = 0;
            var timer = new Timer();
            timer.Interval = 50;
            timer.Tick += (sender, args) =>
            {
                time++;
                game.Tick();
                Invalidate();

            };
            timer.Start();
        }
    }
}
