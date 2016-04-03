using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVGFactory.Styles
{
    class SvgStyle
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public string AttributeString()
        {
            string attribute = String.Empty;

            //Ensure a values has been set
            if (!String.IsNullOrEmpty(Name) && !String.IsNullOrEmpty(Value))
            {
                attribute = String.Format("{0}:{1};", Name, Value);
            }

            return attribute.ToString();
        }

    }
}
