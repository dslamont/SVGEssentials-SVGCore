using SVGFactory.Styles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SVGFactory.Elements
{
    public class SvgLine : ISVGElement
    {
        public int X1 { get; set; }
        public int Y1 { get; set; }
        public int X2 { get; set; }
        public int Y2 { get; set; }
        public Dictionary<string, string> NameSpaces { get; set; }
        public SvgStyleCollection Styles { get; set; }

        #region "Constructors"

        public SvgLine(int x1, int y1, int x2, int y2)
        {
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;

            NameSpaces = new Dictionary<string, string>();
            Styles = new SvgStyleCollection();
        }

        #endregion        

        #region "Rendering"
        public void Render(XmlWriter writer)
        {
            if (writer != null)
            {
                writer.WriteStartElement("line");

                writer.WriteAttributeString("x1", X1.ToString());
                writer.WriteAttributeString("y1", Y1.ToString());
                writer.WriteAttributeString("x2", X2.ToString());
                writer.WriteAttributeString("y2", Y2.ToString());

                //Add any styles
                if (Styles != null)
                {
                    if (Styles.HasStyles())
                    {
                        writer.WriteAttributeString("style", Styles.AttributeString());
                    }
                }

                writer.WriteEndElement();

            }
        }

        #endregion
    }
}
