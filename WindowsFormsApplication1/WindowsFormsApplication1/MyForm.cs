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

            var path = @"C:\Users\dns\Documents\GitHub\game\WindowsFormsApplication1\WindowsFormsApplication1\images\";
            BackgroundImage = Image.FromFile(path + "background.jpg");

            var fireImg = Image.FromFile(path + "fireboy_face.png");
            var waterImg = Image.FromFile(path + "simple_water.jpg");
            var terrainImg = Image.FromFile(path + "terrain.png");

            PaintEventHandler drawingField = (sender, args) => {
                foreach (var cell in game.Field)
                        if (cell.Type == TerrainType.FullSquare)
                        {
                            args.Graphics.DrawImage(terrainImg, 
                                cell.Position.X / Constants.koef, 
                                cell.Position.Y / Constants.koef);
                        }
                
                args.Graphics.DrawImage(fireImg, 
                    game.Field.FireHero.Position.X / Constants.koef, 
                    game.Field.FireHero.Position.Y / Constants.koef);
                
                args.Graphics.DrawImage(waterImg,
                    game.Field.WaterHero.Position.X / Constants.koef,
                    game.Field.WaterHero.Position.Y / Constants.koef);
            };

            Paint += drawingField;

            KeyDown += (sender, args) =>
            {
                switch (args.KeyCode)
                {
                    case Keys.W:
                        game.Field.FireHero.Jump();
                        break;

                    case Keys.D:
                        game.Field.FireHero.MoveRight();
                        fireImg = Image.FromFile(path + "fireboyR.png");
                        break;
                        
                    case Keys.A:
                        game.Field.FireHero.MoveLeft();
                        fireImg = Image.FromFile(path + "fireboyL.png");
                        break;

                    case Keys.W:
                        game.Field.FireHero.Jump();
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
                    case Keys.A:
                        fireImg = Image.FromFile(path + "fireboy_face.png");
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
