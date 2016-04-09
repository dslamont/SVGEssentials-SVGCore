using SVGCore.Styles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SVGCore.Elements
{
    public class SvgRect : ISVGElement
    {
        private int _x;
        private int _y;
        private int _width;
        private int _height;

        public Dictionary<string, string> NameSpaces { get; set; }
        public SvgStyleCollection Styles { get; set; }

        #region "Constructors" 

        public SvgRect(int centreX, int centreY, int width, int height)
        {
            X = centreX;
            Y = centreY;
            Width = width;
            Height = height;

            NameSpaces = new Dictionary<string, string>();
            Styles = new SvgStyleCollection();
        }

        #endregion

        #region "Properties"

        public int X
        {
            get
            {
                return _x;
            }

            set
            {
                if (value < 0)
                {
                    _x = 0;
                }
                else
                {
                    _x = value;
                }
            }
        }

        public int Y
        {
            get
            {
                return _y;
            }

            set
            {
                if (value < 0)
                {
                    _y = 0;
                }
                else
                {
                    _y = value;
                }
            }
        }
        public int Width
        {
            get
            {
                return _width;
            }

            set
            {
                if (value < 0)
                {
                    _width = 0;
                }
                else
                {
                    _width = value;
                }
            }
        }

        public int Height
        {
            get
            {
                return _height;
            }

            set
            {
                if (value < 0)
                {
                    _height = 0;
                }
                else
                {
                    _height = value;
                }
            }
        }
        #endregion

        #region "Rendering"

        public void Render(XmlWriter writer)
        {
            if (writer != null)
            {
                writer.WriteStartElement("rect");

                writer.WriteAttributeString("x", X.ToString());
                writer.WriteAttributeString("y", Y.ToString());
                writer.WriteAttributeString("width", Width.ToString());
                writer.WriteAttributeString("height", Height.ToString());

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
