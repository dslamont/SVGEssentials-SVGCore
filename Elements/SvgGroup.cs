using SVGFactory.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SVGFactory.Elements
{
    public class SvgGroup : ISVGElement
    {

        public string Id { get; set; }

        public Dictionary<string, string> NameSpaces { get; set; }

        protected List<ISVGElement> ChildElements { get; set; }


        #region "Constructors"

        public SvgGroup()
        {
            Id = String.Empty;

            ChildElements = new List<ISVGElement>();

            NameSpaces = new Dictionary<string, string>();
        }

        public SvgGroup(string id)
        {
            Id = id;
        }

        #endregion

        #region "Child Elements"

        public void AddChild(ISVGElement child)
        {
            //Ensure a valid Cgild Element has been supplied 
            if (child != null)
            {
                //Ensure the Child Elements list has been instantiated
                if (ChildElements == null)
                {
                    ChildElements = new List<ISVGElement>();
                }

                //Store the supplied child elements
                ChildElements.Add(child);
            }
        }

        #endregion

        #region "Rendering"
        public void Render(XmlWriter writer)
        {
            if (writer != null)
            {
                writer.WriteStartElement("g");

                if (!String.IsNullOrEmpty(Id))
                {
                    writer.WriteAttributeString("id", Id);
                }

                //string styleAttribute = StyleAttribute();
                //if (!String.IsNullOrEmpty(styleAttribute))
                //{
                //    writer.WriteAttributeString("style", styleAttribute);
                //}

                foreach (ISVGElement child in ChildElements)
                {
                    child.Render(writer);
                }

                writer.WriteEndElement();

            }
        }

        #endregion

    }
}
