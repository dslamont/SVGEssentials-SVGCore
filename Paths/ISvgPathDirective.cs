using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVGCore.Paths
{
    public interface ISvgPathDirective
    {
        bool Absolute { get; set; }
        string AttributeString();
    }
}
