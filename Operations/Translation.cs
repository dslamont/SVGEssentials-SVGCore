using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVGCore.Operations
{
    public class Translation : IOperation
    {
        public int X { get; set; }
        public int Y { get; set; }

        public string Name { get; set; }

        #region "Constructors"

        public Translation(int x, int y)
        {
            X = x;
            Y = y;

            Name = "translate";
        }

        #endregion

        #region "Attribute String"

        public string AttributeString()
        {
            return String.Format("translate({0} {1})", X, Y);
        }

        #endregion
    }
}
