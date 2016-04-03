using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVGFactory.Paths
{
    public class SvgPathArc : ISvgPathDirective
    {
        public bool Absolute { get; set; }

        public int XRadius { get; set; }
        public int YRadius { get; set; }
        public int XAxisRotation { get; set; }
        public bool LargeArcFlag { get; set; }
        public bool SweepFlag { get; set; }
        public int X { get; set; }
        public int Y { get; set; }


        #region "Constructors"

        public SvgPathArc(int xRadius, int yRadius, int xAxisRot, bool largeArc, bool sweepFlag, int x, int y, bool absolute)
        {
            XRadius = xRadius;
            YRadius = yRadius;
            XAxisRotation = xAxisRot;
            LargeArcFlag = largeArc;
            SweepFlag = sweepFlag;
            X = x;
            Y = y;
            Absolute = absolute;
            
        }

        #endregion

        #region "Attributes"

        public string AttributeString()
        {
            string attributeText = String.Empty;

            string flag = "a";

            if (Absolute)
            {
                flag = "A";
            }

            //int xAxisRotValue = XAxisRotation ? 1 : 0;
            attributeText = String.Format("{0} {1} {2} {3} {4} {5} {6} {7} ", flag, XRadius, YRadius, XAxisRotation, LargeArcFlag ? 1 : 0, SweepFlag ? 1 : 0, X, Y);

            return attributeText;
        }

        #endregion
    }
}
