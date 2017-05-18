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
            var game = new Game();
            ClientSize = new Size(Constants.TerrainSquareLength * game.Field.Width, 
                                    Constants.TerrainSquareLength * game.Field.Heigh);
            BackgroundImage = Image.FromFile(@"A:\Users\Александр\Documents\GitHub\game\WindowsFormsApplication1\WindowsFormsApplication1\images\background.jpg");
 
            PaintEventHandler drawingField = (sender, args) => {
                var myGraphics = CreateGraphics();
                for (var row = 0; row < game.Field.Heigh; row++)
                    for (var column = 0; column < game.Field.Width; column++)
                    {
                        if (game.Field[row, column].Type == TerrainType.FullSquare)
                        {
                            Bitmap myBitmap = new Bitmap(@"A:\Users\Александр\Documents\GitHub\game\WindowsFormsApplication1\WindowsFormsApplication1\images\simple_terrain.jpg");
                            myGraphics.DrawImage(myBitmap, game.Field[row, column].Position);

                        }
                    }
            };
            var myOwnGraphics = CreateGraphics();
            PaintEventHandler drawingHeroes = (sender, args) => {
                //???Поменять картинку на прямоугольник с кистью картинки
                Bitmap myBitmap = new Bitmap(@"A:\Users\Александр\Documents\GitHub\game\WindowsFormsApplication1\WindowsFormsApplication1\images\simple_fire.jpg");
                myOwnGraphics.DrawImage(myBitmap, game.FireHero.StartPosition);
            };

            Paint += drawingField + drawingHeroes;
            Invalidate();

            KeyPress += (sender, args) =>
            {
                if (args.KeyChar.ToString().ToLower() == "d")
                    game.FireHero.MoveRight();
                Invalidate();
            };
            
        }
    }
}
