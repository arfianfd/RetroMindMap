using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroMindMap
{
    public class MenuNew : IMenuNew
    {
        public string Name { set; get; }
        public MenuNew(string name)
        {
            this.Name = name;
        }
        public void Action(object sender, EventArgs e)
        {
            NewWindow baru = new NewWindow("baru");
        }
    }
}