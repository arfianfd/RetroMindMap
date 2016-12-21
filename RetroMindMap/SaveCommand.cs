using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace RetroMindMap
{
    public class SaveCommand : ICommand
    {
        public void Execute()
        {
            SubEditor subeditor = MainWindow.getInstance().editor.GetSelectedCanvas();
            if (subeditor == null)
            {
                MessageBox.Show("Tidak ada yang disave");
                return;
            }
            

            SaveFileDialog saveDlg = new SaveFileDialog();
            saveDlg.Filter = "XML Files|*.xml|All Files|*.*";
            if (DialogResult.OK == saveDlg.ShowDialog())
            {
                string fileName = saveDlg.FileName;

                XmlWriter writer = new XmlWriter();
                writer.WriteStartDocument();
                string canvasType = IEditor.GetSelectedCanvas();
                writer.WriteStartElement("List." + diagramType);
                foreach (ICanvas o in canvas)
                {
                    writer.Append(o.XMLEncode());
                }
                writer.WriteEndElement();

                using (System.IO.StreamWriter file = new System.IO.StreamWriter(fileName))
                {
                    file.Write(writer.GetXml());
                }
            }
        }
    }
}
