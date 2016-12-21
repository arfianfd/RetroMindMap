using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroMindMap
{
    public class XmlWriter
    {
        private String xml;
        private Stack<String> elements;
        private String xmlHeader = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\n";

        public String XmlHeader
        {
            get
            {
                return xmlHeader;
            }
        }

        public XmlWriter()
        {
            xml = "";
            elements = new Stack<String>();
        }

        public void WriteStartDocument()
        {
            xml += xmlHeader;
        }

        public void WriteElementString(String element, String value)
        {
            xml += "<" + element + ">" + value + "</" + element + ">\n";
        }

        public void WriteStartElement(String element)
        {
            xml += "<" + element + ">\n";
            elements.Push(element);
        }

        public void WriteEndElement()
        {
            xml += "</" + elements.Pop() + ">\n";
        }

        public bool Append(String xmlElement)
        {
            if (IsValidXml(xmlElement)) {
                xml += xmlElement;
                return true;
            }
            return false;
        }

        public bool IsValidXml(String xmlElement)
        {
            // belom dibuat logikanya!!
            return true;
        }

        public void Reset()
        {
            // harus ngecek dulu stacknya udah kosong apa nggak
            xml = "";
        }

        public String GetXml(bool isSilent = false)
        {
            // cek dulu stacknya udah kosong apa nggak
            String ans = xml;
            if (!isSilent)
            {
                Reset();
            }
            return ans;
        }
    }
}
