using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroMindMap
{
    public interface ISubmenu
    {
        string Name { set; get; }
        void Action(object sender, EventArgs e);
    }
}
