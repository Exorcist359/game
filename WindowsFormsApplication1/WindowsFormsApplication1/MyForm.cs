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

        private static string path = @"A:\Users\Александр\Documents\GitHub\game\WindowsFormsApplication1\WindowsFormsApplication1\images\";
        private Image fireImg = Image.FromFile(path + "fireboy_face.png");
        private Image waterImg = Image.FromFile(path + "watergirl_face.png");
        private Image terrainImg = Image.FromFile(path + "terrain.png");
        private Image mudTerrainImg = Image.FromFile(path + "terrain_mud.png");
        private Image fireTerrainImg = Image.FromFile(path + "terrain_fire.png");
        private Image waterTerrainImg = Image.FromFile(path + "terrain_water.png");
        private Image redDoor = Image.FromFile(path + "redDoor.png");
        private Image blueDoor = Image.FromFile(path + "blueDoor.png");
        private Image endImg = Image.FromFile(path + "end.png");
        
        bool isUp = false;
        bool isR = false;
        bool isL = false;

        public MyForm()
        {
            DoubleBuffered = true;
            var game = new Game();
            ClientSize = new Size(Constants.TerrainSquareLength * game.Field.Width / Constants.koef, 
                                    Constants.TerrainSquareLength * game.Field.Heigh / Constants.koef);

            BackgroundImage = Image.FromFile(path + "background.jpg");
            
            PaintEventHandler drawingField = (sender, args) =>
            {
                foreach (var cell in game.Field)
                    if (cell.Type == TerrainType.FullSquare)
                    {
                        var img = terrainImg;
                        if (cell.Surface == SurfaceType.Mud)
                            img = mudTerrainImg;
                        if (cell.Surface == SurfaceType.Fire)
                            img = fireTerrainImg;
                        if (cell.Surface == SurfaceType.Water)
                            img = waterTerrainImg;

                        args.Graphics.DrawImage(img,
                            cell.Position.X / Constants.koef,
                            cell.Position.Y / Constants.koef);
                    }

                if (game.Field.FireHero.IsDying || game.Field.WaterHero.IsDying)
                {
                    args.Graphics.DrawImage(endImg,
                                    ClientSize.Width/50, ClientSize.Height/50);
                    
                }

                args.Graphics.DrawImage(redDoor,
                                    game.Field.FireExit.Position.X / Constants.koef - 25,
                                    game.Field.FireExit.Position.Y / Constants.koef - 93);

                args.Graphics.DrawImage(blueDoor,
                                    game.Field.WaterExit.Position.X / Constants.koef - 25,
                                    game.Field.WaterExit.Position.Y / Constants.koef - 93);

                args.Graphics.DrawImage(fireImg, 
                    game.Field.FireHero.Position.X / Constants.koef, 
                    game.Field.FireHero.Position.Y / Constants.koef);

                args.Graphics.DrawImage(waterImg,
                    game.Field.WaterHero.Position.X / Constants.koef,
                    game.Field.WaterHero.Position.Y / Constants.koef);
            };

            Paint += drawingField;
            var keys = new List<Keys>();

            KeyDown += MyForm_KeyDown;

            KeyUp += MyForm_KeyUp;

            var time = 0;
            var timer = new Timer();
            timer.Interval = 5;
            timer.Tick += (sender, args) =>
            {
                time++;
                game.Tick();
                DoMoving(game);
                Invalidate();
            };
            timer.Start();
        }

        private void MyForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
                isUp = true;
            if (e.KeyCode == Keys.A)
                isL = true;
            if (e.KeyCode == Keys.D)
                isR = true;
        }


        private void MyForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
                isUp = false;
            if (e.KeyCode == Keys.A)
                isL = false;
            if (e.KeyCode == Keys.D)
                isR = false;
        }

        public void DoMoving(Game game)
        {
            if (isUp)
            {
                game.Field.FireHero.Jump();
                isUp = false;
            }
            if (isL)
            {
                game.Field.FireHero.MoveLeft();
                fireImg = Image.FromFile(path + "fireboyL.png");
            }
            if (isR)
            {
                game.Field.FireHero.MoveRight();
                fireImg = Image.FromFile(path + "fireboyR.png");
            //}
            //foreach (var key in keys)
            //    switch (key)
            //        {
            //            case Keys.D:
            //                break;

            //            case Keys.A:
            //                break;

            //            case Keys.W:

            //                break;

            //            case Keys.Right:
            //                game.Field.WaterHero.MoveRight();
            //                waterImg = Image.FromFile(path + "watergirlR.png");
            //                break;

            //            case Keys.Left:
            //                game.Field.WaterHero.MoveLeft();
            //                waterImg = Image.FromFile(path + "watergirlL.png");
            //                break;

            //            case Keys.Up:
            //                game.Field.WaterHero.Jump();
            //                break;
                    }
        }

    }
}
