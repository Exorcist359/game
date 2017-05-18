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
            ClientSize = new Size(Constants.TerrainSquareLength * game.Field.Width / Constants.koef, 
                                    Constants.TerrainSquareLength * game.Field.Heigh / Constants.koef);
            BackgroundImage = Image.FromFile(@"C:\Users\dns\Documents\GitHub\game\WindowsFormsApplication1\WindowsFormsApplication1\images\background.jpg");
 
            PaintEventHandler drawingField = (sender, args) => {
                for (var row = 0; row < game.Field.Heigh; row++)
                    for (var column = 0; column < game.Field.Width; column++)
                    {
                        if (game.Field[row, column].Type == TerrainType.FullSquare)
                        {
                            Bitmap myBitmap = new Bitmap(@"C:\Users\dns\Documents\GitHub\game\WindowsFormsApplication1\WindowsFormsApplication1\images\simple_terrain.jpg");
                            args.Graphics.DrawImage(myBitmap, new Point(game.Field[row, column].Position.X / Constants.koef, game.Field[row, column].Position.Y / Constants.koef));

                        }
                    }
                Bitmap hero = new Bitmap(@"C:\Users\dns\Documents\GitHub\game\WindowsFormsApplication1\WindowsFormsApplication1\images\simple_fire.jpg");
                args.Graphics.DrawImage(hero, new Point(game.Field.FireHero.Position.X / Constants.koef, game.Field.FireHero.Position.Y / Constants.koef));
                hero = new Bitmap(@"C:\Users\dns\Documents\GitHub\game\WindowsFormsApplication1\WindowsFormsApplication1\images\simple_water.jpg");
                args.Graphics.DrawImage(hero, new Point(game.Field.WaterHero.Position.X / Constants.koef, game.Field.WaterHero.Position.Y / Constants.koef));
            };

            Paint += drawingField;
             Invalidate();
            KeyDown += (sender, args) =>
            {
                //if (args.KeyCode == Keys.D)
                //    game.FireHero.MoveRight();
                //if (args.KeyCode == Keys.A)
                //    game.FireHero.MoveLeft();
                

                switch (args.KeyCode)
                {
                    case Keys.W:
                        game.Field.FireHero.Jump();
                        break;

                    case Keys.D:
                        game.Field.FireHero.MoveRight();
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

            var time = 0;
            var timer = new Timer();
            timer.Interval = 5;
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
