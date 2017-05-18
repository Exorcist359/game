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
            BackgroundImage = Image.FromFile(@"A:\Users\Александр\Documents\GitHub\game\WindowsFormsApplication1\WindowsFormsApplication1\images\background.jpg");
 
            PaintEventHandler drawingField = (sender, args) => {
                for (var row = 0; row < game.Field.Heigh; row++)
                    for (var column = 0; column < game.Field.Width; column++)
                    {
                        if (game.Field[row, column].Type == TerrainType.FullSquare)
                        {
                            Bitmap myBitmap = new Bitmap(@"A:\Users\Александр\Documents\GitHub\game\WindowsFormsApplication1\WindowsFormsApplication1\images\simple_terrain.jpg");
                            args.Graphics.DrawImage(myBitmap, game.Field[row, column].Position);

                        }
                    }
                Bitmap hero = new Bitmap(@"A:\Users\Александр\Documents\GitHub\game\WindowsFormsApplication1\WindowsFormsApplication1\images\simple_fire.jpg");
                args.Graphics.DrawImage(hero, game.FireHero.Position);
                hero = new Bitmap(@"A:\Users\Александр\Documents\GitHub\game\WindowsFormsApplication1\WindowsFormsApplication1\images\simple_water.jpg");
                args.Graphics.DrawImage(hero, game.WaterHero.Position);
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
                    case Keys.D:
                        game.FireHero.MoveRight();
                        break;

                    case Keys.A:
                        game.FireHero.MoveLeft();
                        break;

                    case Keys.Right:
                        game.WaterHero.MoveRight();
                        break;

                    case Keys.Left:
                        game.WaterHero.MoveLeft();
                        break;
                }
                
            };

            var time = 0;
            var timer = new Timer();
            timer.Interval = 50;
            timer.Tick += (sender, args) =>
            {
                time++;
                Invalidate();
            };
            timer.Start();
        }
    }
}
