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
            var panel = new Panel
            {
                //BackgroundImage = 
            };
            
        }
    }
}
