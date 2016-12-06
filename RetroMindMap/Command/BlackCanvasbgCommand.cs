using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroMindMap.Commands
{
    public class BlackCanvasbgCommand : ICommand
    {
        private ICanvas canvas;

        public BlackCanvasbgCommand(ICanvas canvas)
        {
            this.canvas = canvas;
        }

        public void Execute()
        {
            Debug.WriteLine("Change background color to black");
            this.canvas.SetBackgroundColor(Color.Black);
            this.canvas.Repaint();
        }
    }
}
