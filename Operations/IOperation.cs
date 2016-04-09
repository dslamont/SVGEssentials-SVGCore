using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVGCore.Operations
{
    public interface IOperation
    {
        string Name { get; set; }
        string AttributeString();


    }
}
