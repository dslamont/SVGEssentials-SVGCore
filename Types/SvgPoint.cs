using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVGCore.Types
{
    public class SvgPoint
    {
        public int X { get; set; }
        public int Y { get; set; }

        #region "Constructors"

        public SvgPoint(int x, int y)
        {
            X = x;
            Y = y;
        }

        #endregion
    }
}
