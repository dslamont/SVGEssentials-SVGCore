using SVGFactory.Styles;
using SVGFactory.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SVGFactory.Elements
{
    public class SvgPolyLine : ISVGElement
    {
        public Dictionary<string, string> NameSpaces { get; set; }
        public SvgStyleCollection Styles { get; set; }
        public List<SvgPoint> Points { get; set; }

        #region "Constructor"

        public SvgPolyLine()
        {
            Points = new List<SvgPoint>();
            NameSpaces = new Dictionary<string, string>();
            Styles = new SvgStyleCollection();
        }

        #endregion

        #region "Points"

        public void AddPoint(int x, int y)
        {
            Points.Add(new SvgPoint(x, y));
        }

        protected string PointsString()
        {
            StringBuilder pointsString = new StringBuilder();

            if(Points != null)
            {
                bool firstPointProcessed = false;
                foreach(SvgPoint point in Points)
                {
                    if(firstPointProcessed)
                    {
                        pointsString.Append(", ");
                        
                    }
                    else
                    {
                        //FLag that the 1st point has been processed
                        firstPointProcessed = true;
                    }

                    pointsString.Append(point.X);
                    pointsString.Append(" ");
                    pointsString.Append(point.Y);
                }
            }

            return pointsString.ToString();
        }

        #endregion
        
        #region "Rendering"
        public void Render(XmlWriter writer)
        {
            if (writer != null)
            {
                writer.WriteStartElement("polyline");

                //Add any points
                if(Points != null)
                {
                    writer.WriteAttributeString("points", PointsString());
                }

                //Add any styles
                if(Styles != null)
                {
                    if(Styles.HasStyles())
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
