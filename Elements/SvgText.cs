using SVGFactory.Styles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SVGFactory.Elements
{
    public class SvgText : ISVGElement
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string Text { get; set; }
        public Dictionary<string, string> NameSpaces { get; set; }
        public SvgStyleCollection Styles { get; set; }

        #region "Constructor"

        public SvgText(int x, int y, string text)
        {
            NameSpaces = new Dictionary<string, string>();
            Styles = new SvgStyleCollection();

            X = x;
            Y = y;
            Text = text;
        }

        #endregion

        #region "Rendering"
        public void Render(XmlWriter writer)
        {
            if (writer != null)
            {
                writer.WriteStartElement("text");

                //Set anchor point
                writer.WriteAttributeString("x", X.ToString());
                writer.WriteAttributeString("y", Y.ToString());

                //Add any styles
                if (Styles != null)
                {
                    if (Styles.HasStyles())
                    {
                        writer.WriteAttributeString("style", Styles.AttributeString());
                    }
                }

                //Output the text to display
                writer.WriteString(Text);

                writer.WriteEndElement();

            }
        }

        #endregion
    }
}
