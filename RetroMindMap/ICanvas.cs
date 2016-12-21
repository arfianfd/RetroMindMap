using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroMindMap
{
    public interface ICanvas
    {
        String Name { get; set; }
        public bool isDeleted { set; get; }
        DrawingObject drawingObject;
        System.Windows.Forms.Control ActiveControl { get; set; }
        ITool GetActiveTool();
        void SetActiveTool(ITool tool);
        void Repaint();
        void SetBackgroundColor(Color color);

        void AddDrawingObject(drawingObject);
        void RemoveDrawingObject(drawingObject);

        DrawingObject GetObjectAt(int x, int y);
        DrawingObject SelectObjectAt(int x, int y);
        void DeselectAllObjects();
    }


    public string XMLEncode()
    {
        string result;
        XmlWriter writer = new XmlWriter();
        writer.WriteStartElement(this.GetType().FullName);

        writer.WriteElementString("X", x + "");
        writer.WriteElementString("Y", y + "");
        writer.WriteElementString("objectName", DrawingObject + "");
        writer.WriteElementString("isDeleted", isDeleted ? "1" : "0");
        writer.WriteEndElement();

        writer.WriteEndElement();
        result = writer.GetXml();
        return result;
    }

    public void XMLDecode(Map obj)
    {
        Console.WriteLine("Object created from open");
        this.x = Int32.Parse((string)obj["X"]);
        this.y = Int32.Parse((string)obj["Y"]);
        this.objectName = (string)obj["objectName"];
        this.isDeleted = (string)obj["isDeleted"] == "1" ? true : false;
    }
}