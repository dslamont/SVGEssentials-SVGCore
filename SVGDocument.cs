using SVGFactory.Elements;
using SVGFactory.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SVGFactory
{
    public class SVGDocument

    {
        public Stream OutputStream { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        protected List<ISVGElement> ChildElements { get; set; }

        #region "Constructors"

        public SVGDocument()
        {
            ChildElements = new List<ISVGElement>();
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

        #region "Name Spaces"

        protected Dictionary<string, string> NameSpaces()
        {
            Dictionary<string, string> nameSpaces = new Dictionary<string, string>();

            //Add default svg namespace 
            //nameSpaces.Add("svg", "http://www.w3.org/2000/svg");

            //Ensure there are Child Elements
            if (ChildElements != null)
            {
                //Loop through all the child elements
                foreach (ISVGElement child in ChildElements)
                {
                    if (child.NameSpaces != null)
                    {
                        //Are there namespaces
                        if (child.NameSpaces.Count > 0)
                        {
                            //Loop through the name spaces
                            foreach (string nsKey in child.NameSpaces.Keys)
                            {
                                //Ensure we haven't alread added the name space
                                if (!nameSpaces.ContainsKey(nsKey.ToLower()))
                                {
                                    nameSpaces.Add(nsKey.ToLower(), child.NameSpaces[nsKey]);
                                }
                            }
                        }

                    }
                }
            }

            //Return the names spaces to be added
            return nameSpaces;
        }
        #endregion 

        #region "Rendering"

        public string Render()
        {
            string temp = "Rendering...";

            using (Utf8StringWriter stringWriter = new Utf8StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(stringWriter))
                {
                    Render(writer);
                }

                temp = stringWriter.ToString();
            }

            return temp;
        }

        public void Render(string filePath)
        {
            //Ensure a valid file path has been supplied 
            if (!String.IsNullOrEmpty(filePath))
            {
                using (StreamWriter fileWriter = new StreamWriter(filePath))
                {
                    XmlWriterSettings settings = new XmlWriterSettings();
                    settings.Indent = true;

                    using (XmlWriter writer = XmlWriter.Create(fileWriter, settings))
                    {
                        Render(writer);
                    }

                }
            }
        }

        public void Render(XmlWriter writer)
        {
            if (writer != null)
            {
                Dictionary<string, string> nameSpaces = NameSpaces();

                writer.WriteStartDocument();
                writer.WriteDocType("svg", "-//W3C//DTD SVG 1.1//EN", "http://www.w3.org/Graphics/SVG/1.1/DTD/svg11.dtd", null);

                writer.WriteStartElement("svg", "http://www.w3.org/2000/svg");
                writer.WriteAttributeString("width", "140");
                writer.WriteAttributeString("height", "170");

                //Add name spaces 
                foreach(string nsKey in nameSpaces.Keys)
                {
                    switch(nsKey)
                    {
                        case "svg":
                            //writer.WriteAttributeString("xmlns", "", null, nameSpaces[nsKey]);
                            //writer.WriteAttributeString("xmlns", nameSpaces[nsKey]);
                            break;
                        default:
                            writer.WriteAttributeString("xmlns", nsKey, null, nameSpaces[nsKey]);
                            break;
                    }
                    
                }
                // Write the price.
                writer.WriteElementString("title", Title);
                writer.WriteElementString("desc", Description);


                foreach (ISVGElement child in ChildElements)
                {
                    child.Render(writer);
                }
                //writer.WriteStartElement("circle");

                //writer.WriteAttributeString("cx", "70");
                //writer.WriteAttributeString("cy", "95");
                //writer.WriteAttributeString("r", "50");
                //writer.WriteAttributeString("style", "stroke:black; fill:none;");

                //writer.WriteEndElement();

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }

        #endregion

    }
}
