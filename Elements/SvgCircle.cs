using SVGFactory.Styles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SVGFactory.Elements
{
    public class SvgCircle : ISVGElement
    {
        private int _x;
        private int _y;
        private int _radius;

        public Dictionary<string, string> NameSpaces { get; set; }
        public SvgStyleCollection Styles { get; set; }

        #region "Constructors" 

        public SvgCircle(int centreX, int centreY, int radius)
        {
            X = centreX;
            Y = centreY;
            Radius = radius;

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
        public int Radius
        {
            get
            {
                return _radius;
            }

            set
            {
                if (value < 0)
                {
                    _radius = 0;
                }
                else
                {
                    _radius = value;
                }
            }
        }
        #endregion
        
        #region "Rendering"

        public void Render(XmlWriter writer)
        {
            if (writer != null)
            {
                writer.WriteStartElement("circle");

                //writer.WriteAttributeString("cx", "70.5");
                //writer.WriteAttributeString("cy", "95.5");
                //writer.WriteAttributeString("r", "50");
                writer.WriteAttributeString("cx", X.ToString());
                writer.WriteAttributeString("cy", Y.ToString());
                writer.WriteAttributeString("r", Radius.ToString());
                //writer.WriteAttributeString("style", "stroke:black; fill:none;");

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
