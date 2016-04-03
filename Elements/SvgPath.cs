using SVGFactory.Paths;
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
    public class SvgPath : ISVGElement
    {
        public Dictionary<string, string> NameSpaces { get; set; }
        public SvgStyleCollection Styles { get; set; }
        public List<ISvgPathDirective> PathDirectives { get; set; }

        #region "Constructor"

        public SvgPath()
        {
            PathDirectives = new List<ISvgPathDirective>();
            NameSpaces = new Dictionary<string, string>();
            Styles = new SvgStyleCollection();
        }

        #endregion

        #region "Path Directives"

        public void AddDirective(ISvgPathDirective directive)
        {
            //Ensure a valid directive has been supplied 
            if (directive != null)
            {

                //Ensure the directive storage has been 
                if (PathDirectives == null)
                {
                    PathDirectives = new List<ISvgPathDirective>();
                }

                //Store the supplied directive
                PathDirectives.Add(directive);
            }
        }

        private string AttributeString()
        {
            StringBuilder text = new StringBuilder();

            //Ensure Directive have been added
            if(PathDirectives != null)
            {
                //Loop through the directives
                bool firstEntry = true;
                foreach(ISvgPathDirective directive in PathDirectives)
                {
                    if(!firstEntry)
                    {
                        //Add directive seperator
                        text.Append(" ");
                    }
                    else
                    {
                        //Flag that we have dealt with the first directive
                        firstEntry = false;
                    }

                    //Append the directive
                    text.Append(directive.AttributeString());
                }
            }

            return text.ToString();
        }

        #endregion

        #region "Rendering"
        public void Render(XmlWriter writer)
        {
            if (writer != null)
            {
                writer.WriteStartElement("path");

                //Add any path directives
                if (PathDirectives != null)
                {
                    writer.WriteAttributeString("d", AttributeString());
                }

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
