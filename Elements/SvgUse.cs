using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SVGCore.Elements;
using System.Xml;
using SVGCore.Operations;

namespace SVGCore.Elements
{
    public class SvgUse : ISVGElement
    {
        public Dictionary<string, string> NameSpaces { get; set; }

        public Transform TranslationOp { get; set; }

        protected string _id  { get; set; }

        #region "Constructors"

        public SvgUse()
        {
            _id = String.Empty;

            NameSpaces = new Dictionary<string, string>();
            NameSpaces.Add("xlink", "http://www.w3.org/1999/xlink");
            
        }

        #endregion 

        #region "Methods"

        public void SetAssociatedId(string id)
        {
            if(!String.IsNullOrEmpty(id))
            {
                //Ensure a # pre-pends the id 
                if(!id.StartsWith("#"))
                {
                    _id = String.Format("#{0}", id);
                }
                else
                {
                    _id = id;
                }
            }
            else
            {
                _id = String.Empty;
            }
        }

        public void AddTransform(Transform transform)
        {
            TranslationOp = transform;
        }
        
        #endregion

        #region "Rendering"
        public void Render(XmlWriter writer)
        {
            if (writer != null)
            {
                writer.WriteStartElement("use");

                if (!String.IsNullOrEmpty(_id))
                {
                    writer.WriteAttributeString("xlink", "href", null, _id);

                    //Ouptut any transform operations
                    if(TranslationOp != null)
                    {
                        if (TranslationOp.HasOperations())
                        {
                            writer.WriteAttributeString("transform", TranslationOp.AttributeString());
                        }
                    }
                }


                writer.WriteEndElement();

            }
        }

        #endregion
    }
}
