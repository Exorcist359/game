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

            

            
            Paint += (sender, args) =>
            {
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
            Invalidate();

        }
    }
}
