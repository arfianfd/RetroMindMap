using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RetroMindMap
{
    public class SubmenuSave : ISubmenu
    {
        public string Name { set; get; }
        public SubmenuSave(string name)
        {
            this.Name = name;
        }
        public void Action(object sender, EventArgs e)
        {
            SaveCommand saveCommand = new SaveCommand();
            saveCommand.Execute();
        }
    }
}
