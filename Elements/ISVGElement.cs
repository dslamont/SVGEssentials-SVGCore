using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SVGFactory.Elements
{
    /// <summary>
    /// Interface for all SVG Elements
    /// </summary>
    public interface ISVGElement
    {
        void Render(XmlWriter writer);

        Dictionary<string, string> NameSpaces { get; set; }
    }
}
