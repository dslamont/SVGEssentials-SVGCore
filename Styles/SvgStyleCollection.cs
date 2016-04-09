using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVGCore.Styles
{
    public class SvgStyleCollection
    {
        public Dictionary<string, string> Styles { get; set; }

        #region "Constructors"

        public SvgStyleCollection()
        {
            //Create the collection of Styles
            Styles = new Dictionary<string, string>();
        }

        #endregion

        #region "Adding"

        public void AddStyle(string name, string value)
        {
            //Ensure a valid style has been supplied
            if (!String.IsNullOrEmpty(name) && !String.IsNullOrEmpty(value))
            {
                //Ensure there is valid storage
                if (Styles == null)
                {
                    Styles = new Dictionary<string, string>();
                }

                //Remove any previous style of the same type
                if (Styles.ContainsKey(name))
                {
                    Styles.Remove(name);
                }

                //Add the new Style
                Styles.Add(name, value);
            }
        }

        #endregion

        #region "Rendering"

        public bool HasStyles()
        {
            bool hasStyles = false;

            if (Styles != null)
            {
                if (Styles.Count > 0)
                {
                    hasStyles = true;
                }
            }

            return hasStyles;
        }

        public string AttributeString()
        {
            StringBuilder attributeText = new StringBuilder();

            bool firstStyle =true;
            foreach (string operation in Styles.Keys)
            {
                //Do we need to pre-pend a seperator
                if (!firstStyle)
                {
                    //Pre-pend the seperator
                    attributeText.Append("; ");
                }
                else
                {
                    //Flag that we have dealt with the first entry
                    firstStyle = false;
                }

                //Append the style
                attributeText.AppendFormat("{0}:{1}", operation, Styles[operation]);
            }

            return attributeText.ToString();
        }

        #endregion

    }
}
