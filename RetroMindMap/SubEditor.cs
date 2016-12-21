using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RetroMindMap
{
    public class SubEditor : ISubEditor
    {
        public TabPage Tabpage { get; set; }
        public string NameSubEditor { set; get; }
        public int IndexSubEditor { set; get; }
        public ICanvas Canvas { set; get; }
        public SubEditor(string NameSubEditor, ICanvas TypeSubEditor, int IndexSubEditor)
        {
            Console.WriteLine("constructing subeditor");
            Canvas = new DefaultCanvas();
            Tabpage = new TabPage();

            this.NameSubEditor = NameSubEditor;
            this.Canvas = TypeSubEditor;
            this.IndexSubEditor = IndexSubEditor;

            Tabpage.Name = this.NameSubEditor;
            Tabpage.Text = this.IndexSubEditor + 1 + ".   " + this.NameSubEditor + " (" + this.Canvas.Name.Replace(" (Conceptual Data Model)", "").Replace(" (Physical Data Model)", "") + ")";

            Tabpage.Controls.Add(Canvas.ActiveControl);
            this.Canvas = TypeSubEditor;
        }
    }
}
