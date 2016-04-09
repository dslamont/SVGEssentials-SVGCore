using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVGCore.Paths
{
    public class SvgPathLineTo : ISvgPathDirective
    {
        public bool Absolute { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        #region "Constructors"


        public SvgPathLineTo(int x, int y) : this(x, y, false)
        {

        }
        public SvgPathLineTo(int x, int y, bool absolute)
        {
            X = x;
            Y = y;
            Absolute = absolute;
        }

        #endregion

        #region "Attributes"

        public string AttributeString()
        {
            string attributeText = String.Empty;
            string flag = "l";

            if (Absolute)
            {
                flag = "L";
            }

            attributeText = String.Format("{0} {1} {2}", flag, X, Y);

            return attributeText;
        }

        #endregion

    }
}
