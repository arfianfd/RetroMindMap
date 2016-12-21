using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RetroMindMap
{
    public interface ISubEditor
    {
        TabPage Tabpage { get; set; }
        string NameSubEditor { set; get; }
        int IndexSubEditor { set; get; }
        ICanvas Canvas { set; get; }
    }
}
